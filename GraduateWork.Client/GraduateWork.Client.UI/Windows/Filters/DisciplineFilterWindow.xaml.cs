using System.Linq;
using System.Windows;
using GraduateWork.Common.Tables.Enums;

namespace GraduateWork.Client.UI.Windows.Filters {
	public partial class DisciplineFilterWindow {
		public bool UseFilters { get; private set; }
		public string DisciplineName { get; private set; }
		public ControlType? ControlType { get; private set; }
		public string GroupName { get; private set; }

		public DisciplineFilterWindow() {
			InitializeComponent();
			ComboBoxControlType.ItemsSource = new[] { string.Empty }.Concat(CommonMethods.Enum.GetControlTypeNames());

			SetEnabledControls();
		}
		private void SetEnabledControls() {
			var isEnabled = CheckBoxUseFilters.IsChecked == true;

			CommonMethods.Set.Enabled(LabelDisciplineName, TextBoxDisciplineName, isEnabled);
			CommonMethods.Set.Enabled(LabelControlType, ComboBoxControlType, isEnabled);
			CommonMethods.Set.Enabled(LabelGroupName, TextBoxGroupName, isEnabled);
		}

		private void CheckBoxUseFilters_OnChecked(object sender, RoutedEventArgs e) {
			SetEnabledControls();
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			var selectedControlType = (string)ComboBoxControlType.SelectedItem;

			UseFilters = CheckBoxUseFilters.IsChecked == true;
			DisciplineName = TextBoxDisciplineName.Text;
			ControlType = string.IsNullOrEmpty(selectedControlType) ? null : (ControlType?)CommonMethods.Enum.GetControlTypeValue(selectedControlType);
			GroupName = TextBoxGroupName.Text;
			Hide();
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			Hide();
		}
	}
}