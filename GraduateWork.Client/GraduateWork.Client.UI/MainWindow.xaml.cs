using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GraduateWork.Client.Client;
using GraduateWork.Client.UI.TableWindows;
using GraduateWork.Common;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Client.UI {
	public partial class MainWindow {
		private const string clientUiSettingsFileName = "GraduateWork.Client.UI.Settings.xml";
		private readonly IHttpClient httpClient = new HttpClient();
		private readonly ClientUiSettings clientUiSettings;

		public MainWindow() {
			InitializeComponent();
			clientUiSettings = LoadClientUiSettings();
		}
		private ClientUiSettings LoadClientUiSettings() {
			var settings = FileSettings.ReadSettings<ClientUiSettings>(clientUiSettingsFileName);
			TextBoxServerAddress.Text = settings.ServerAddress;
			TextBoxUserLogin.Text = settings.UserLogin;
			PasswordBoxUserPassword.Password = settings.UserPassword;
			CheckBoxSaveLoginAndPassword.IsChecked = settings.SaveLoginAndPassword;

			httpClient.ServerAddress = settings.ServerAddress;
			httpClient.Login = settings.UserLogin;
			httpClient.Password = settings.UserPassword;

			return settings;
		}

		private void MainWindow_OnClosing(object sender, CancelEventArgs e) {
			var saveLoginAndPassword = CheckBoxSaveLoginAndPassword.IsChecked == true;
			clientUiSettings.ServerAddress = TextBoxServerAddress.Text;
			clientUiSettings.UserLogin = saveLoginAndPassword ? TextBoxUserLogin.Text : string.Empty;
			clientUiSettings.UserPassword = saveLoginAndPassword ? PasswordBoxUserPassword.Password : string.Empty;
			clientUiSettings.SaveLoginAndPassword = saveLoginAndPassword;

			FileSettings.WriteSettings(clientUiSettings, clientUiSettingsFileName);
		}

		private void ButtonConnectToServer_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.SafeRunMethod.WithoutReturn(() => {
				httpClient.ServerAddress = TextBoxServerAddress.Text;
				httpClient.Ping();
			},
				"Соединение было успешно установлено");
		}
		private void ButtonSingIn_OnClick(object sender, RoutedEventArgs e) {
			var login = TextBoxUserLogin.Text;
			var password = PasswordBoxUserPassword.Password;

			CommonMethods.SafeRunMethod.WithoutReturn(() => {
				httpClient.CheckUserIsExist(login, password);
				httpClient.Login = login;
				httpClient.Password = password;
			},
				$"Вы выполнили вход под пользователем '{login}'");
		}

		private void DataGridUsers_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			if (DataGridUsers.SelectedItem == null)
				return;

			var user = CommonMethods.SafeRunMethod.WithReturn(() => httpClient.GetExtendedUser((UserBasedProxy)DataGridUsers.SelectedItem));
			new UserWindow(user, true).ShowDialog();
		}
		private void MenuItemAddUser_OnClick(object sender, RoutedEventArgs e) {
			var userWindow = new UserWindow(null, false);
			if (userWindow.ShowDialog() != true)
				return;

			CommonMethods.SafeRunMethod.WithoutReturn(() => httpClient.AddUser(userWindow.User));
		}
		private void MenuItemEditUser_OnClick(object sender, RoutedEventArgs e) {
			if (DataGridUsers.SelectedItem == null)
				return;

			var oldUser = CommonMethods.SafeRunMethod.WithReturn(() =>
				httpClient.GetExtendedUser((UserBasedProxy)DataGridUsers.SelectedItem));

			var userWindow = new UserWindow(oldUser, false);
			if (userWindow.ShowDialog() != true)
				return;

			CommonMethods.SafeRunMethod.WithoutReturn(() => httpClient.EditUser(oldUser, userWindow.User));
		}
		private void MenuItemDeleteUser_OnClick(object sender, RoutedEventArgs e) {
			if (DataGridUsers.SelectedItem == null)
				return;

			var user = CommonMethods.SafeRunMethod.WithReturn(() =>
				httpClient.GetExtendedUser((UserBasedProxy)DataGridUsers.SelectedItem));
			CommonMethods.SafeRunMethod.WithoutReturn(() => httpClient.DeleteUser(user));
		}

		private void ButtonUserFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateUsers_OnClick(object sender, RoutedEventArgs e) {
			DataGridUsers.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(() => httpClient.GetAllUsers());
		}
		private void ButtonGroupFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateGroups_OnClick(object sender, RoutedEventArgs e) {
			DataGridGroups.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(() => httpClient.GetAllGroups());
		}
		private void ButtonDisciplineFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateDisciplines_OnClick(object sender, RoutedEventArgs e) {
			DataGridDisciplines.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(() => httpClient.GetAllDisciplines());
		}
		private void ButtonStudentFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateStudents_OnClick(object sender, RoutedEventArgs e) {
			DataGridStudents.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(() => httpClient.GetAllStudents());
		}
	}
}