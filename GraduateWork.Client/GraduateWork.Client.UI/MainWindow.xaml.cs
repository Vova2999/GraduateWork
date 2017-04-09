using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GraduateWork.Client.Client;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Client.UI.TableWindows;
using GraduateWork.Common;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI {
	public partial class MainWindow {
		private readonly IHttpClient httpClient = new HttpClient();
		private readonly ClientUiSettings clientUiSettings;

		public MainWindow() {
			InitializeComponent();
			clientUiSettings = LoadClientUiSettings();

			DataGridDisciplines.LoadTable(typeof(DisciplineBasedProxy));
			DataGridGroups.LoadTable(typeof(GroupBasedProxy));
			DataGridStudents.LoadTable(typeof(StudentBasedProxy));
			DataGridUsers.LoadTable(typeof(UserBasedProxy));
		}
		private ClientUiSettings LoadClientUiSettings() {
			var settings = FileSettings.ReadSettings<ClientUiSettings>(ClientUiSettings.FileName);
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

			FileSettings.WriteSettings(clientUiSettings, ClientUiSettings.FileName);
		}

		private void ButtonConnectToServer_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.SafeRunMethod.WithoutReturn(() => {
				httpClient.ServerAddress = TextBoxServerAddress.Text;
				httpClient.Ping();
			}, "Соединение было успешно установлено");
		}
		private void ButtonSingIn_OnClick(object sender, RoutedEventArgs e) {
			var login = TextBoxUserLogin.Text;
			var password = PasswordBoxUserPassword.Password;

			CommonMethods.SafeRunMethod.WithoutReturn(() => {
				httpClient.CheckUserIsExist(login, password);
				httpClient.Login = login;
				httpClient.Password = password;
			}, $"Вы выполнили вход под пользователем '{login}'");
		}

		private void DataGridDisciplines_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			var groupNames = CommonMethods.SafeRunMethod.WithReturn(() => httpClient.GetAllGroups()).Select(group => group.GroupName).ToArray();
			CommonMethods.WorkWithTables.View((DisciplineBasedProxy)DataGridDisciplines.SelectedItem, httpClient.GetExtendedDiscipline, (proxy, isReadOnly) => new DisciplineWindow(proxy, groupNames, isReadOnly));
		}
		private void MenuItemAddDiscipline_OnClick(object sender, RoutedEventArgs e) {
			var groupNames = CommonMethods.SafeRunMethod.WithReturn(() => httpClient.GetAllGroups()).Select(group => group.GroupName).ToArray();
			CommonMethods.WorkWithTables.Add(default(DisciplineExtendedProxy), (proxy, isReadOnly) => new DisciplineWindow(proxy, groupNames, isReadOnly), httpClient.AddDiscipline, window => window.Discipline);
			UpdateDataGridDisciplines();
		}
		private void MenuItemEditDiscipline_OnClick(object sender, RoutedEventArgs e) {
			var groupNames = CommonMethods.SafeRunMethod.WithReturn(() => httpClient.GetAllGroups()).Select(group => group.GroupName).ToArray();
			CommonMethods.WorkWithTables.Edit((DisciplineBasedProxy)DataGridDisciplines.SelectedItem, httpClient.GetExtendedDiscipline, (proxy, isReadOnly) => new DisciplineWindow(proxy, groupNames, isReadOnly), httpClient.EditDiscipline, window => window.Discipline);
			UpdateDataGridDisciplines();
		}
		private void MenuItemDeleteDiscipline_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Delete((DisciplineBasedProxy)DataGridDisciplines.SelectedItem, httpClient.GetExtendedDiscipline, httpClient.DeleteDiscipline);
			UpdateDataGridDisciplines();
		}

		private void DataGridGroups_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			CommonMethods.WorkWithTables.View((GroupBasedProxy)DataGridGroups.SelectedItem, httpClient.GetExtendedGroup, (proxy, isReadOnly) => new GroupWindow(proxy, isReadOnly));
		}
		private void MenuItemAddGroup_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Add(default(GroupExtendedProxy), (proxy, isReadOnly) => new GroupWindow(proxy, isReadOnly), httpClient.AddGroup, window => window.Group);
			UpdateDataGridGroups();
		}
		private void MenuItemEditGroup_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Edit((GroupBasedProxy)DataGridGroups.SelectedItem, httpClient.GetExtendedGroup, (proxy, isReadOnly) => new GroupWindow(proxy, isReadOnly), httpClient.EditGroup, window => window.Group);
			UpdateDataGridGroups();
		}
		private void MenuItemDeleteGroup_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Delete((GroupBasedProxy)DataGridGroups.SelectedItem, httpClient.GetExtendedGroup, httpClient.DeleteGroup);
			UpdateDataGridGroups();
		}

		private void DataGridStudents_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			CommonMethods.WorkWithTables.View((StudentBasedProxy)DataGridStudents.SelectedItem, httpClient.GetExtendedStudent, (proxy, isReadOnly) => new StudentWindow(proxy, isReadOnly));
		}
		private void MenuItemAddStudent_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Add(default(StudentExtendedProxy), (proxy, isReadOnly) => new StudentWindow(proxy, isReadOnly), httpClient.AddStudent, window => window.Student);
			UpdateDataGridStudents();
		}
		private void MenuItemEditStudent_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Edit((StudentBasedProxy)DataGridStudents.SelectedItem, httpClient.GetExtendedStudent, (proxy, isReadOnly) => new StudentWindow(proxy, isReadOnly), httpClient.EditStudent, window => window.Student);
			UpdateDataGridStudents();
		}
		private void MenuItemDeleteStudent_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Delete((StudentBasedProxy)DataGridStudents.SelectedItem, httpClient.GetExtendedStudent, httpClient.DeleteStudent);
			UpdateDataGridStudents();
		}

		private void DataGridUsers_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			CommonMethods.WorkWithTables.View((UserBasedProxy)DataGridUsers.SelectedItem, httpClient.GetExtendedUser, (proxy, isReadOnly) => new UserWindow(proxy, isReadOnly));
		}
		private void MenuItemAddUser_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Add(default(UserExtendedProxy), (proxy, isReadOnly) => new UserWindow(proxy, isReadOnly), httpClient.AddUser, window => window.User);
			UpdateDataGridUsers();
		}
		private void MenuItemEditUser_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Edit((UserBasedProxy)DataGridUsers.SelectedItem, httpClient.GetExtendedUser, (proxy, isReadOnly) => new UserWindow(proxy, isReadOnly), httpClient.EditUser, window => window.User);
			UpdateDataGridUsers();
		}
		private void MenuItemDeleteUser_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Delete((UserBasedProxy)DataGridUsers.SelectedItem, httpClient.GetExtendedUser, httpClient.DeleteUser);
			UpdateDataGridUsers();
		}

		private void ButtonDisciplineFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonGroupFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonStudentFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUserFilters_OnClick(object sender, RoutedEventArgs e) {
		}
		private void ButtonUpdateDisciplines_OnClick(object sender, RoutedEventArgs e) {
			UpdateDataGridDisciplines();
		}
		private void ButtonUpdateGroups_OnClick(object sender, RoutedEventArgs e) {
			UpdateDataGridGroups();
		}
		private void ButtonUpdateStudents_OnClick(object sender, RoutedEventArgs e) {
			UpdateDataGridStudents();
		}
		private void ButtonUpdateUsers_OnClick(object sender, RoutedEventArgs e) {
			UpdateDataGridUsers();
		}

		private void UpdateDataGridDisciplines() {
			DataGridDisciplines.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(httpClient.GetAllDisciplines);
		}
		private void UpdateDataGridGroups() {
			DataGridGroups.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(httpClient.GetAllGroups);
		}
		private void UpdateDataGridStudents() {
			DataGridStudents.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(httpClient.GetAllStudents);
		}
		private void UpdateDataGridUsers() {
			DataGridUsers.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(httpClient.GetAllUsers);
		}
	}
}