using System.Collections.Generic;
using System.Windows;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.Windows.Tables {
	public partial class DisciplineWindow : IProxyWindowWithExtendedProxy<DisciplineExtendedProxy> {
		public DisciplineExtendedProxy ExtendedProxy { get; private set; }
		public bool IsReadOnly { get; }

		public DisciplineWindow(DisciplineExtendedProxy discipline, string[] groupNames, bool isReadOnly) {
			InitializeComponent();

			ExtendedProxy = discipline?.GetExtendedClone() ?? new DisciplineExtendedProxy();
			IsReadOnly = isReadOnly;

			SetGroupFields(groupNames);
			SetReadOnly();
		}
		private void SetGroupFields(string[] groupNames) {
			TextBoxDisciplineName.Text = ExtendedProxy.DisciplineName;
			ComboBoxGroupName.ItemsSource = groupNames;
			ComboBoxGroupName.SelectedItem = ExtendedProxy.GroupName;
			ComboBoxControlType.ItemsSource = CommonMethods.Enum.GetControlTypeNames();
			ComboBoxControlType.SelectedItem = CommonMethods.Enum.GetControlTypeName(ExtendedProxy.ControlType);
			TextBoxTotalHours.Text = ExtendedProxy.TotalHours.ToString();
			TextBoxClassHours.Text = ExtendedProxy.ClassHours.ToString();
		}
		private void SetReadOnly() {
			CommonMethods.Set.ReadOnly(TextBoxDisciplineName, IsReadOnly);
			CommonMethods.Set.ReadOnly(ComboBoxGroupName, IsReadOnly);
			CommonMethods.Set.ReadOnly(ComboBoxControlType, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxTotalHours, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxClassHours, IsReadOnly);
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.TrueDialogResult(this);
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.FalseDialogResult(this);
		}

		public IEnumerable<string> GetErrors() {
			if (CommonMethods.Check.FieldIsEmpty(TextBoxDisciplineName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelDisciplineName);

			if (CommonMethods.Check.FieldIsEmpty(ComboBoxGroupName))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelGroupName);

			if (CommonMethods.Check.FieldIsEmpty(ComboBoxControlType))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelControlType);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxTotalHours))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelTotalHours);
			else if (CommonMethods.Check.FieldIsNotNumber(TextBoxTotalHours))
				yield return CommonMethods.GenerateMessage.FieldIsNotNumber(LabelTotalHours);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxClassHours))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelClassHours);
			else if (CommonMethods.Check.FieldIsNotNumber(TextBoxClassHours))
				yield return CommonMethods.GenerateMessage.FieldIsNotNumber(LabelClassHours);
		}
		public void WriteProxy() {
			ExtendedProxy.DisciplineName = TextBoxDisciplineName.Text;
			ExtendedProxy.GroupName = (string)ComboBoxGroupName.SelectedItem;
			ExtendedProxy.ControlType = CommonMethods.Enum.GetControlTypeValue((string)ComboBoxControlType.SelectedItem);
			ExtendedProxy.TotalHours = TextBoxTotalHours.Text.ToInt();
			ExtendedProxy.ClassHours = TextBoxClassHours.Text.ToInt();
		}
	}
}