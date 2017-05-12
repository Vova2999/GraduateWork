using System.Windows;

namespace GraduateWork.Client.UI.Windows.Filters {
	public partial class UserFilterWindow {
		public bool UseFilters { get; private set; }
		public string UserLogin { get; private set; }

		public UserFilterWindow() {
			InitializeComponent();

			SetEnabledControls();
		}
		private void SetEnabledControls() {
			var isEnabled = CheckBoxUseFilters.IsChecked == true;

			CommonMethods.Set.Enabled(LabelUserLogin, TextBoxUserLogin, isEnabled);
		}

		private void CheckBoxUseFilters_OnChecked(object sender, RoutedEventArgs e) {
			SetEnabledControls();
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			UseFilters = CheckBoxUseFilters.IsChecked == true;
			UserLogin = TextBoxUserLogin.Text;
			Hide();
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			Hide();
		}
	}
}