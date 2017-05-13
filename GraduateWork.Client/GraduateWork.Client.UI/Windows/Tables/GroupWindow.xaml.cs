using System.Collections.Generic;
using System.Windows;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.Windows.Tables {
	public partial class GroupWindow : IProxyWindowWithExtendedProxy<GroupExtendedProxy> {
		public GroupExtendedProxy ExtendedProxy { get; private set; }
		public bool IsReadOnly { get; }

		public GroupWindow(GroupExtendedProxy group, bool isReadOnly) {
			InitializeComponent();

			ExtendedProxy = group?.GetExtendedClone() ?? new GroupExtendedProxy();
			IsReadOnly = isReadOnly;

			DataGridStudents.LoadTable(typeof(StudentBasedProxy));
			DataGridDisciplines.LoadTable(typeof(DisciplineBasedProxy));

			SetGroupFields();
			SetReadOnly();
		}
		private void SetGroupFields() {
			TextBoxGroupName.Text = ExtendedProxy.GroupName;
			TextBoxSpecialtyName.Text = ExtendedProxy.SpecialtyName;
			TextBoxSpecialtyNumber.Text = ExtendedProxy.SpecialtyNumber.ToString();
			TextBoxFacultyName.Text = ExtendedProxy.FacultyName;
			DataGridStudents.ItemsSource = ExtendedProxy.Students;
			DataGridDisciplines.ItemsSource = ExtendedProxy.Disciplines;
		}
		private void SetReadOnly() {
			CommonMethods.Set.ReadOnly(TextBoxGroupName, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxSpecialtyName, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxSpecialtyNumber, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxFacultyName, IsReadOnly);
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.TrueDialogResult(this);
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.FalseDialogResult(this);
		}

		public IEnumerable<string> GetErrors() {
			if (CommonMethods.Check.FieldIsEmpty(TextBoxGroupName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelGroupName);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxSpecialtyName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelSpecialtyName);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxSpecialtyNumber))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelSpecialtyNumber);
			else if (CommonMethods.Check.FieldIsNotNumber(TextBoxSpecialtyNumber))
				yield return CommonMethods.GenerateMessage.FieldIsNotNumber(LabelSpecialtyNumber);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxFacultyName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelFacultyName);
		}
		public void WriteProxy() {
			ExtendedProxy.GroupName = TextBoxGroupName.Text;
			ExtendedProxy.SpecialtyName = TextBoxSpecialtyName.Text;
			ExtendedProxy.SpecialtyNumber = TextBoxSpecialtyNumber.Text.ToInt();
			ExtendedProxy.FacultyName = TextBoxFacultyName.Text;
		}
	}
}