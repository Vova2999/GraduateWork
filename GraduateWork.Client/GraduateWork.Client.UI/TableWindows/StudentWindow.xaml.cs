using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.TableWindows {
	// ReSharper disable PossibleInvalidOperationException

	public partial class StudentWindow : IProxyWindowWithExtendedProxy<StudentExtendedProxy> {
		private readonly Func<string, AssessmentByDiscipline[]> getAssessmentByDisciplinesFromGroupName;
		public StudentExtendedProxy ExtendedProxy { get; private set; }
		public bool IsReadOnly { get; }

		public StudentWindow(StudentExtendedProxy student, string[] groupNames, Func<string, AssessmentByDiscipline[]> getAssessmentByDisciplinesFromGroupName, bool isReadOnly) {
			InitializeComponent();
			this.getAssessmentByDisciplinesFromGroupName = getAssessmentByDisciplinesFromGroupName;

			ExtendedProxy = student?.GetExtendedClone() ?? new StudentExtendedProxy();
			IsReadOnly = isReadOnly;

			DataGridAssessmentByDisciplines.LoadTable(typeof(AssessmentByDiscipline), false);

			SetGroupFields(groupNames);
			SetReadOnly();
		}
		private void SetGroupFields(string[] groupNames) {
			TextBoxFirstName.Text = ExtendedProxy.FirstName;
			TextBoxSecondName.Text = ExtendedProxy.SecondName;
			TextBoxThirdName.Text = ExtendedProxy.ThirdName;
			if (ExtendedProxy.DateOfBirth != default(DateTime))
				DatePickerDateOfBirth.SelectedDate = ExtendedProxy.DateOfBirth;
			TextBoxPreviousEducationName.Text = ExtendedProxy.PreviousEducationName;
			TextBoxPreviousEducationYear.Text = ExtendedProxy.PreviousEducationYear.ToString();
			TextBoxEnrollmentName.Text = ExtendedProxy.EnrollmentName;
			TextBoxEnrollmentYear.Text = ExtendedProxy.EnrollmentYear.ToString();
			TextBoxExpulsionName.Text = ExtendedProxy.ExpulsionName;
			TextBoxExpulsionYear.Text = ExtendedProxy.ExpulsionYear.ToString();
			if (ExtendedProxy.ExpulsionOrderDate != default(DateTime))
				DatePickerExpulsionOrderDate.SelectedDate = ExtendedProxy.ExpulsionOrderDate;
			TextBoxExpulsionOrderNumber.Text = ExtendedProxy.ExpulsionOrderNumber.ToString();
			TextBoxDiplomaTopic.Text = ExtendedProxy.DiplomaTopic;
			ComboBoxDiplomaAssessment.ItemsSource = CommonMethods.Enum.GetAssessmentNames();
			ComboBoxDiplomaAssessment.SelectedItem = CommonMethods.Enum.GetAssessmentName(ExtendedProxy.DiplomaAssessment);
			if (ExtendedProxy.ProtectionDate != default(DateTime))
				DatePickerProtectionDate.SelectedDate = ExtendedProxy.ProtectionDate;
			TextBoxProtocolNumber.Text = ExtendedProxy.ProtocolNumber;
			TextBoxRegistrationNumber.Text = ExtendedProxy.RegistrationNumber;
			if (ExtendedProxy.RegistrationDate != default(DateTime))
				DatePickerRegistrationDate.SelectedDate = ExtendedProxy.RegistrationDate;
			ComboBoxGroupName.ItemsSource = groupNames;
			ComboBoxGroupName.SelectedItem = ExtendedProxy.GroupName;
			DataGridAssessmentByDisciplines.ItemsSource = ExtendedProxy.AssessmentByDisciplines;
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
			CommonMethods.Set.ReadOnly(TextBoxExpulsionName, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxExpulsionYear, IsReadOnly);
			CommonMethods.Set.ReadOnly(DatePickerExpulsionOrderDate, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxExpulsionOrderNumber, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxDiplomaTopic, IsReadOnly);
			CommonMethods.Set.ReadOnly(ComboBoxDiplomaAssessment, IsReadOnly);
			CommonMethods.Set.ReadOnly(DatePickerProtectionDate, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxProtocolNumber, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxRegistrationNumber, IsReadOnly);
			CommonMethods.Set.ReadOnly(DatePickerRegistrationDate, IsReadOnly);
			CommonMethods.Set.ReadOnly(ComboBoxGroupName, IsReadOnly);
			CommonMethods.Set.ReadOnly(DataGridAssessmentByDisciplines, IsReadOnly);
		}

		private void ComboBoxGroupName_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
			DataGridAssessmentByDisciplines.ItemsSource = getAssessmentByDisciplinesFromGroupName((string)ComboBoxGroupName.SelectedItem);
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

			if (CommonMethods.Check.FieldIsEmpty(TextBoxExpulsionName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelExpulsionName);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxExpulsionYear))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelExpulsionYear);
			else if (CommonMethods.Check.FieldIsNotNumber(TextBoxExpulsionYear))
				yield return CommonMethods.GenerateMessage.FieldIsNotNumber(LabelExpulsionYear);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxDiplomaTopic))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelDiplomaTopic);

			if (CommonMethods.Check.FieldIsEmpty(ComboBoxDiplomaAssessment))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelDiplomaAssessment);

			if (CommonMethods.Check.FieldIsEmpty(DatePickerProtectionDate))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelProtectionDate);

			if (CommonMethods.Check.FieldIsEmpty(DatePickerExpulsionOrderDate))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelExpulsionOrderDate);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxExpulsionOrderNumber))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelExpulsionOrderNumber);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxProtocolNumber))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelProtocolNumber);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxRegistrationNumber))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelRegistrationNumber);

			if (CommonMethods.Check.FieldIsEmpty(DatePickerRegistrationDate))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelRegistrationDate);

			if (CommonMethods.Check.FieldIsEmpty(ComboBoxGroupName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelGroupName);
		}
		public void WriteProxy() {
			ExtendedProxy.FirstName = TextBoxFirstName.Text;
			ExtendedProxy.SecondName = TextBoxSecondName.Text;
			ExtendedProxy.ThirdName = TextBoxThirdName.Text;
			ExtendedProxy.DateOfBirth = DatePickerDateOfBirth.SelectedDate.Value;
			ExtendedProxy.PreviousEducationName = TextBoxPreviousEducationName.Text;
			ExtendedProxy.PreviousEducationYear = int.Parse(TextBoxPreviousEducationYear.Text);
			ExtendedProxy.EnrollmentName = TextBoxEnrollmentName.Text;
			ExtendedProxy.EnrollmentYear = int.Parse(TextBoxEnrollmentYear.Text);
			ExtendedProxy.ExpulsionName = TextBoxExpulsionName.Text;
			ExtendedProxy.ExpulsionYear = int.Parse(TextBoxExpulsionYear.Text);
			ExtendedProxy.ExpulsionOrderDate = DatePickerExpulsionOrderDate.SelectedDate.Value;
			ExtendedProxy.ExpulsionOrderNumber = int.Parse(TextBoxExpulsionOrderNumber.Text);
			ExtendedProxy.DiplomaTopic = TextBoxDiplomaTopic.Text;
			ExtendedProxy.DiplomaAssessment = CommonMethods.Enum.GetAssessmentValue((string)ComboBoxDiplomaAssessment.SelectedItem);
			ExtendedProxy.ProtectionDate = DatePickerProtectionDate.SelectedDate.Value;
			ExtendedProxy.ProtocolNumber = TextBoxProtocolNumber.Text;
			ExtendedProxy.RegistrationNumber = TextBoxRegistrationNumber.Text;
			ExtendedProxy.RegistrationDate = DatePickerRegistrationDate.SelectedDate.Value;
			ExtendedProxy.GroupName = (string)ComboBoxGroupName.SelectedItem;
			ExtendedProxy.AssessmentByDisciplines = (AssessmentByDiscipline[])DataGridAssessmentByDisciplines.ItemsSource;
		}
	}
}