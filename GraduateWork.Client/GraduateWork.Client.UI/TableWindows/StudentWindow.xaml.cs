using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class StudentWindow : IProxyWindow {
		public readonly StudentExtendedProxy Student;
		public bool IsReadOnly { get; }

		public StudentWindow(StudentExtendedProxy student, string[] groupNames, bool isReadOnly) {
			InitializeComponent();

			Student = student?.GetExtendedClone() ?? new StudentExtendedProxy();
			IsReadOnly = isReadOnly;

			DataGridAssessmentByDisciplines.LoadTable(typeof(AssessmentByDiscipline), false);

			SetGroupFields(groupNames);
			SetReadOnly();
		}
		private void SetGroupFields(string[] groupNames) {
			TextBoxFirstName.Text = Student.FirstName;
			TextBoxSecondName.Text = Student.SecondName;
			TextBoxThirdName.Text = Student.ThirdName;
			DatePickerDateOfBirth.SelectedDate = Student.DateOfBirth == default(DateTime) ? new DateTime(2000, 1, 1) : Student.DateOfBirth;
			TextBoxPreviousEducationName.Text = Student.PreviousEducationName;
			TextBoxPreviousEducationYear.Text = Student.PreviousEducationYear.ToString();
			TextBoxEnrollmentName.Text = Student.EnrollmentName;
			TextBoxEnrollmentYear.Text = Student.EnrollmentYear.ToString();
			TextBoxDeductionName.Text = Student.DeductionName;
			TextBoxDeductionYear.Text = Student.DeductionYear.ToString();
			TextBoxDiplomaTopic.Text = Student.DiplomaTopic;
			ComboBoxDiplomaAssessment.ItemsSource = CommonMethods.Enum.GetAssessmentNames();
			ComboBoxDiplomaAssessment.SelectedItem = CommonMethods.Enum.GetAssessmentName(Student.DiplomaAssessment);
			DatePickerProtectionDate.SelectedDate = Student.ProtectionDate == default(DateTime) ? new DateTime(2000, 1, 1) : Student.ProtectionDate;
			TextBoxProtocolNumber.Text = Student.ProtocolNumber;
			TextBoxRegistrationNumber.Text = Student.RegistrationNumber;
			DatePickerRegistrationDate.SelectedDate = Student.RegistrationDate == default(DateTime) ? new DateTime(2000, 1, 1) : Student.RegistrationDate;
			ComboBoxGroupName.ItemsSource = groupNames;
			ComboBoxGroupName.SelectedItem = Student.Group?.GroupName;
			DataGridAssessmentByDisciplines.ItemsSource = Student.AssessmentByDisciplines
				.Select(assessmentByDiscipline => new NameAssessmentValueByDiscipline {
					NameOfDiscipline = assessmentByDiscipline.NameOfDiscipline,
					Assessment = CommonMethods.Enum.GetAssessmentName(assessmentByDiscipline.Assessment)
				}).ToArray();
		}
		private void SetReadOnly() {
			CommonMethods.Set.ReadOnly(TextBoxFirstName, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxSecondName, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxThirdName, IsReadOnly);
			CommonMethods.Set.ReadOnly(DatePickerDateOfBirth, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxPreviousEducationName, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxPreviousEducationYear, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxEnrollmentName, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxEnrollmentYear, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxDeductionName, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxDeductionYear, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxDiplomaTopic, IsReadOnly);
			CommonMethods.Set.ReadOnly(ComboBoxDiplomaAssessment, IsReadOnly);
			CommonMethods.Set.ReadOnly(DatePickerProtectionDate, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxProtocolNumber, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxRegistrationNumber, IsReadOnly);
			CommonMethods.Set.ReadOnly(DatePickerRegistrationDate, IsReadOnly);
			CommonMethods.Set.ReadOnly(ComboBoxGroupName, IsReadOnly);
			CommonMethods.Set.ReadOnly(DataGridAssessmentByDisciplines, IsReadOnly);
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.TrueDialogResult(this);
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.FalseDialogResult(this);
		}

		public IEnumerable<string> GetErrors() {
			return new List<string>();
		}
		public void WriteProxy() {
			Student.FirstName=TextBoxFirstName.Text ;
			Student.SecondName=TextBoxSecondName.Text ;
			Student.ThirdName=TextBoxThirdName.Text  ;
			Student.DateOfBirth = DatePickerDateOfBirth.SelectedDate.Value;
			Student.PreviousEducationName=TextBoxPreviousEducationName.Text ;
			Student.PreviousEducationYear=int.Parse(TextBoxPreviousEducationYear.Text ) ;
			Student.EnrollmentName=TextBoxEnrollmentName.Text ;
			Student.EnrollmentYear = int.Parse(TextBoxEnrollmentYear.Text);
			Student.DeductionName=TextBoxDeductionName.Text ;
			Student.DeductionYear=int.Parse(TextBoxDeductionYear.Text );
			Student.DiplomaTopic=TextBoxDiplomaTopic.Text ;
			Student.DiplomaAssessment = CommonMethods.Enum.GetAssessmentValue((string)ComboBoxDiplomaAssessment.ItemsSource);
			Student.ProtectionDate = DatePickerProtectionDate.SelectedDate.Value;
			Student.ProtocolNumber =TextBoxProtocolNumber.Text ;
			Student.RegistrationNumber=TextBoxRegistrationNumber.Text ;
			Student.RegistrationDate = DatePickerRegistrationDate.SelectedDate.Value;

			Student.Group = new GroupExtendedProxy { GroupName = (string)ComboBoxGroupName.SelectedItem };
			var nameAssessmentValueByDisciplines = (NameAssessmentValueByDiscipline[])DataGridAssessmentByDisciplines.ItemsSource;
			foreach (var assessmentByDiscipline in Student.AssessmentByDisciplines)
				assessmentByDiscipline.Assessment = CommonMethods.Enum.GetAssessmentValue(nameAssessmentValueByDisciplines.First(x => x.NameOfDiscipline == assessmentByDiscipline.NameOfDiscipline).Assessment);
		}

		private class NameAssessmentValueByDiscipline {
			public string NameOfDiscipline { get; set; }
			public string Assessment { get; set; }
		}
	}
}