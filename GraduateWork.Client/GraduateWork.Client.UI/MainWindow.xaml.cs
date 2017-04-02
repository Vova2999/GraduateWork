using System;
using System.Windows;
using GraduateWork.Client.Client;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Client.UI {
	public partial class MainWindow {
		private readonly IHttpClient httpClient = new HttpClient();

		public MainWindow() {
			InitializeComponent();
			CreateTables();
		}
		private void CreateTables() {
			DataGridUsers.LoadTable(typeof(UserProxy));
			DataGridGroups.LoadTable(typeof(GroupBasedProxy));
			DataGridDisciplines.LoadTable(typeof(DisciplineBasedProxy));
			DataGridStudents.LoadTable(typeof(StudentBasedProxy));
		}

		private void ButtonConnectToServer_OnClick(object sender, RoutedEventArgs e) {
			SafeRunMethod(() => {
				httpClient.ServerAddress = TextBoxServerAddress.Text;
				httpClient.Ping();
			},
				"Соединение было успешно установлено");
		}
		private void ButtonSingIn_OnClick(object sender, RoutedEventArgs e) {
			var login = TextBoxUserLogin.Text;
			var password = TextBoxUserPassword.Text;

			SafeRunMethod(() => {
				httpClient.CheckUserIsExist(login, password);
				httpClient.Login = login;
				httpClient.Password = password;
			},
				$"Вы выполнили вход под пользователем '{login}'");
		}

		private void ButtonUserFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateUsers_OnClick(object sender, RoutedEventArgs e) {
			SafeRunMethod(() => DataGridUsers.ItemsSource = httpClient.GetAllUsers());
		}
		private void ButtonGroupFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateGroups_OnClick(object sender, RoutedEventArgs e) {
			SafeRunMethod(() => DataGridGroups.ItemsSource = httpClient.GetAllGroups());
		}
		private void ButtonDisciplineFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateDisciplines_OnClick(object sender, RoutedEventArgs e) {
			SafeRunMethod(() => DataGridDisciplines.ItemsSource = httpClient.GetAllDisciplines());
		}
		private void ButtonStudentFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateStudents_OnClick(object sender, RoutedEventArgs e) {
			SafeRunMethod(() => DataGridStudents.ItemsSource = httpClient.GetAllStudents());
		}

		private void SafeRunMethod(Action action, string successfulMessage = null) {
			try {
				action();

				if (!string.IsNullOrEmpty(successfulMessage))
					ShowInformationMessageBox(successfulMessage);
			}
			catch (Exception exception) {
				ShowErrorMessageBox(exception.Message);
			}
		}
		private void ShowErrorMessageBox(string message) {
			MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void ShowInformationMessageBox(string message) {
			MessageBox.Show(message, string.Empty, MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}