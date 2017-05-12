using System.Windows;

namespace GraduateWork.Client.UI.Windows.Filters {
	public partial class GroupFilterWindow {
		public bool UseFilters { get; private set; }
		public string GroupName { get; private set; }

		public GroupFilterWindow() {
			InitializeComponent();

			SetEnabledControls();
		}
		private void SetEnabledControls() {
			var isEnabled = CheckBoxUseFilters.IsChecked == true;

			CommonMethods.Set.Enabled(LabelGroupName, TextBoxGroupName, isEnabled);
		}

		private void CheckBoxUseFilters_OnChecked(object sender, RoutedEventArgs e) {
			SetEnabledControls();
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			UseFilters = CheckBoxUseFilters.IsChecked == true;
			GroupName = TextBoxGroupName.Text;
			Hide();
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			Hide();
		}
	}
}