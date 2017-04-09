using System.Collections.Generic;
using System.Windows;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class GroupWindow : IProxyWindow {
		public readonly GroupExtendedProxy Group;
		public bool IsReadOnly { get; }

		public GroupWindow(GroupExtendedProxy group, bool isReadOnly) {
			InitializeComponent();

			Group = group?.GetExtendedClone() ?? new GroupExtendedProxy();
			IsReadOnly = isReadOnly;

			DataGridStudents.LoadTable(typeof(StudentBasedProxy));
			DataGridDisciplines.LoadTable(typeof(DisciplineBasedProxy));

			SetGroupFields();
			SetReadOnly();
		}
		private void SetGroupFields() {
			TextBoxGroupName.Text = Group.GroupName;
			TextBoxSpecialtyName.Text = Group.SpecialtyName;
			TextBoxSpecialtyNumber.Text = Group.SpecialtyNumber.ToString();
			TextBoxFacultyName.Text = Group.FacultyName;
			DataGridStudents.ItemsSource = Group.Students;
			DataGridDisciplines.ItemsSource = Group.Disciplines;
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
			Group.GroupName = TextBoxGroupName.Text;
			Group.SpecialtyName = TextBoxSpecialtyName.Text;
			Group.SpecialtyNumber = int.Parse(TextBoxSpecialtyNumber.Text);
			Group.FacultyName = TextBoxFacultyName.Text;
		}
	}
}