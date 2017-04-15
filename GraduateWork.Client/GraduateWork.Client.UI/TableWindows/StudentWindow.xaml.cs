using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.TableWindows {
	// ReSharper disable PossibleInvalidOperationException

	public partial class StudentWindow : IProxyWindow {
		public readonly StudentExtendedProxy Student;
		public bool IsReadOnly { get; }

		public StudentWindow(StudentExtendedProxy student, string[] groupNames, bool isReadOnly) {
			InitializeComponent();

			Student = student?.GetExtendedClone() ?? new StudentExtendedProxy();
			IsReadOnly = isReadOnly;

			DataGridAssessmentByDisciplines.LoadTable(typeof(AssessmentByDiscipline), false);

			SetGroupFields(groupNames);
			SetReadOnly(student != null);
		}
		private void SetGroupFields(string[] groupNames) {
			TextBoxFirstName.Text = Student.FirstName;
			TextBoxSecondName.Text = Student.SecondName;
			TextBoxThirdName.Text = Student.ThirdName;
			if (Student.DateOfBirth != default(DateTime))
				DatePickerDateOfBirth.SelectedDate = Student.DateOfBirth;
			TextBoxPreviousEducationName.Text = Student.PreviousEducationName;
			TextBoxPreviousEducationYear.Text = Student.PreviousEducationYear.ToString();
			TextBoxEnrollmentName.Text = Student.EnrollmentName;
			TextBoxEnrollmentYear.Text = Student.EnrollmentYear.ToString();
			TextBoxDeductionName.Text = Student.DeductionName;
			TextBoxDeductionYear.Text = Student.DeductionYear.ToString();
			TextBoxDiplomaTopic.Text = Student.DiplomaTopic;
			ComboBoxDiplomaAssessment.ItemsSource = CommonMethods.Enum.GetAssessmentNames();
			ComboBoxDiplomaAssessment.SelectedItem = CommonMethods.Enum.GetAssessmentName(Student.DiplomaAssessment);
			if (Student.ProtectionDate != default(DateTime))
				DatePickerProtectionDate.SelectedDate = Student.ProtectionDate;
			TextBoxProtocolNumber.Text = Student.ProtocolNumber;
			TextBoxRegistrationNumber.Text = Student.RegistrationNumber;
			if (Student.RegistrationDate != default(DateTime))
				DatePickerRegistrationDate.SelectedDate = Student.RegistrationDate;
			ComboBoxGroupName.ItemsSource = groupNames;
			ComboBoxGroupName.SelectedItem = Student.Group?.GroupName;
			DataGridAssessmentByDisciplines.ItemsSource = Student.AssessmentByDisciplines?
				.Select(assessmentByDiscipline => new NameAssessmentValueByDiscipline {
					NameOfDiscipline = assessmentByDiscipline.NameOfDiscipline,
					Assessment = CommonMethods.Enum.GetAssessmentName(assessmentByDiscipline.Assessment)
				}).ToArray();
		}
		private void SetReadOnly(bool readOnlyComboBoxGroupName) {
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
			CommonMethods.Set.ReadOnly(ComboBoxGroupName, readOnlyComboBoxGroupName || IsReadOnly);
			CommonMethods.Set.ReadOnly(DataGridAssessmentByDisciplines, IsReadOnly);
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.TrueDialogResult(this);
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.FalseDialogResult(this);
		}

		public IEnumerable<string> GetErrors() {
			if (CommonMethods.Check.FieldIsEmpty(TextBoxFirstName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelFirstName);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxSecondName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelSecondName);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxThirdName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelThirdName);

			if (CommonMethods.Check.FieldIsEmpty(DatePickerDateOfBirth))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelDateOfBirth);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxPreviousEducationName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelPreviousEducationName);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxPreviousEducationYear))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelPreviousEducationYear);
			else if (CommonMethods.Check.FieldIsNotNumber(TextBoxPreviousEducationYear))
				yield return CommonMethods.GenerateMessage.FieldIsNotNumber(LabelPreviousEducationYear);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxEnrollmentName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelEnrollmentName);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxEnrollmentYear))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelEnrollmentYear);
			else if (CommonMethods.Check.FieldIsNotNumber(TextBoxEnrollmentYear))
				yield return CommonMethods.GenerateMessage.FieldIsNotNumber(LabelEnrollmentYear);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxDeductionName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelDeductionName);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxDeductionYear))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelDeductionYear);
			else if (CommonMethods.Check.FieldIsNotNumber(TextBoxDeductionYear))
				yield return CommonMethods.GenerateMessage.FieldIsNotNumber(LabelDeductionYear);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxDiplomaTopic))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelDiplomaTopic);

			if (CommonMethods.Check.FieldIsEmpty(ComboBoxDiplomaAssessment))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelDiplomaAssessment);

			if (CommonMethods.Check.FieldIsEmpty(DatePickerProtectionDate))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelProtectionDate);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxProtocolNumber))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelProtocolNumber);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxRegistrationNumber))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelRegistrationNumber);

			if (CommonMethods.Check.FieldIsEmpty(DatePickerRegistrationDate))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelRegistrationDate);

			if (CommonMethods.Check.FieldIsEmpty(ComboBoxGroupName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelGroupName);

			if (DataGridAssessmentByDisciplines.ItemsSource == null)
				yield break;
			foreach (var disciplineName in ((NameAssessmentValueByDiscipline[])DataGridAssessmentByDisciplines.ItemsSource)
				.Where(assessmentByDiscipline => string.IsNullOrEmpty(assessmentByDiscipline.Assessment))
				.Select(assessmentByDiscipline => assessmentByDiscipline.NameOfDiscipline))
				yield return $"Выберите оценку для предмета '{disciplineName}'";
		}
		public void WriteProxy() {
			Student.FirstName = TextBoxFirstName.Text;
			Student.SecondName = TextBoxSecondName.Text;
			Student.ThirdName = TextBoxThirdName.Text;
			Student.DateOfBirth = DatePickerDateOfBirth.SelectedDate.Value;
			Student.PreviousEducationName = TextBoxPreviousEducationName.Text;
			Student.PreviousEducationYear = int.Parse(TextBoxPreviousEducationYear.Text);
			Student.EnrollmentName = TextBoxEnrollmentName.Text;
			Student.EnrollmentYear = int.Parse(TextBoxEnrollmentYear.Text);
			Student.DeductionName = TextBoxDeductionName.Text;
			Student.DeductionYear = int.Parse(TextBoxDeductionYear.Text);
			Student.DiplomaTopic = TextBoxDiplomaTopic.Text;
			Student.DiplomaAssessment = CommonMethods.Enum.GetAssessmentValue((string)ComboBoxDiplomaAssessment.SelectedItem);
			Student.ProtectionDate = DatePickerProtectionDate.SelectedDate.Value;
			Student.ProtocolNumber = TextBoxProtocolNumber.Text;
			Student.RegistrationNumber = TextBoxRegistrationNumber.Text;
			Student.RegistrationDate = DatePickerRegistrationDate.SelectedDate.Value;
			Student.Group = new GroupExtendedProxy { GroupName = (string)ComboBoxGroupName.SelectedItem };
			var nameAssessmentValueByDisciplines = (NameAssessmentValueByDiscipline[])DataGridAssessmentByDisciplines.ItemsSource;

			if (Student.AssessmentByDisciplines == null)
				return;
			foreach (var assessmentByDiscipline in Student.AssessmentByDisciplines)
				assessmentByDiscipline.Assessment = CommonMethods.Enum.GetAssessmentValue(nameAssessmentValueByDisciplines
					.First(x => x.NameOfDiscipline == assessmentByDiscipline.NameOfDiscipline).Assessment);
		}

		private class NameAssessmentValueByDiscipline {
			public string NameOfDiscipline { get; set; }
			public string Assessment { get; set; }
		}
	}
}