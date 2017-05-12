using System;
using System.Windows;

namespace GraduateWork.Client.UI.Windows.Filters {
	public partial class StudentFilterWindow {
		public bool UseFilters { get; private set; }
		public string FirstName { get; private set; }
		public string SecondName { get; private set; }
		public string ThirdName { get; private set; }
		public DateTime? DateOfBirth { get; private set; }

		public StudentFilterWindow() {
			InitializeComponent();

			SetEnabledControls();
		}
		private void SetEnabledControls() {
			var isEnabled = CheckBoxUseFilters.IsChecked == true;

			CommonMethods.Set.Enabled(LabelFirstName, TextBoxFirstName, isEnabled);
			CommonMethods.Set.Enabled(LabelSecondName, TextBoxSecondName, isEnabled);
			CommonMethods.Set.Enabled(LabelThirdName, TextBoxThirdName, isEnabled);
			CommonMethods.Set.Enabled(LabelDateOfBirth, DatePickerDateOfBirth, isEnabled);
		}

		private void CheckBoxUseFilters_OnChecked(object sender, RoutedEventArgs e) {
			SetEnabledControls();
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			UseFilters = CheckBoxUseFilters.IsChecked == true;
			FirstName = TextBoxFirstName.Text;
			SecondName = TextBoxSecondName.Text;
			ThirdName = TextBoxThirdName.Text;
			DateOfBirth = DatePickerDateOfBirth.SelectedDate;
			Hide();
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			Hide();
		}
	}
}