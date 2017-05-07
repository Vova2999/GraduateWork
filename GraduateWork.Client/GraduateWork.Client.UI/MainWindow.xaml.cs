using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Client.UI {
	public partial class MainWindow {
		private readonly HttpClientProvider httpClientProvider;
		private readonly ClientUiSettings clientUiSettings;

		private DisciplineBasedProxy SelectedDiscipline => (DisciplineBasedProxy)DataGridDisciplines.SelectedItem;
		private GroupBasedProxy SelectedGroup => (GroupBasedProxy)DataGridGroups.SelectedItem;
		private StudentBasedProxy SelectedStudent => (StudentBasedProxy)DataGridStudents.SelectedItem;
		private UserBasedProxy SelectedUser => (UserBasedProxy)DataGridUsers.SelectedItem;

		public MainWindow() {
			InitializeComponent();
			clientUiSettings = LoadClientUiSettings();
			httpClientProvider = new HttpClientProvider(clientUiSettings.ServerAddress, clientUiSettings.UserLogin, clientUiSettings.UserPassword);

			DataGridDisciplines.LoadTable(typeof(DisciplineBasedProxy));
			DataGridGroups.LoadTable(typeof(GroupBasedProxy));
			DataGridStudents.LoadTable(typeof(StudentBasedProxy));
			DataGridUsers.LoadTable(typeof(UserBasedProxy));
		}
		private ClientUiSettings LoadClientUiSettings() {
			var settings = ClientUiSettings.ReadSettings();
			TextBoxServerAddress.Text = settings.ServerAddress;
			TextBoxUserLogin.Text = settings.UserLogin;
			PasswordBoxUserPassword.Password = settings.UserPassword;
			CheckBoxSaveLoginAndPassword.IsChecked = settings.SaveLoginAndPassword;

			return settings;
		}

		private void MainWindow_OnClosing(object sender, CancelEventArgs e) {
			var saveLoginAndPassword = CheckBoxSaveLoginAndPassword.IsChecked == true;
			clientUiSettings.ServerAddress = httpClientProvider.ServerAddress;
			clientUiSettings.UserLogin = saveLoginAndPassword ? httpClientProvider.Login : string.Empty;
			clientUiSettings.UserPassword = saveLoginAndPassword ? httpClientProvider.Password : string.Empty;
			clientUiSettings.SaveLoginAndPassword = saveLoginAndPassword;

			clientUiSettings.WriteSettings();
		}

		private void ButtonConnectToServer_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.SafeRunMethod.WithoutReturn(() => {
				httpClientProvider.GetParameretsClient().SetServerAddress(TextBoxServerAddress.Text);
				TextBoxServerAddress.Text = httpClientProvider.ServerAddress;
			}, "Соединение было успешно установлено");
		}
		private void ButtonSingIn_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.SafeRunMethod.WithoutReturn(() =>
					httpClientProvider.GetParameretsClient().SetLoginAndPassword(TextBoxUserLogin.Text, PasswordBoxUserPassword.Password),
				$"Вы выполнили вход под пользователем '{TextBoxUserLogin.Text}'");
		}

		private void DataGridDisciplines_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			CommonMethods.WorkWithTables.View(SelectedDiscipline, httpClientProvider.GetDatabaseDisciplineReader(), CommonMethods.GetWindow.Discipline(httpClientProvider));
		}
		private void MenuItemAddDiscipline_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Add(CommonMethods.GetWindow.Discipline(httpClientProvider), httpClientProvider.GetDatabaseDisciplineEditor());
			UpdateDataGridDisciplines();
		}
		private void MenuItemEditDiscipline_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Edit(SelectedDiscipline, httpClientProvider.GetDatabaseDisciplineReader(), CommonMethods.GetWindow.Discipline(httpClientProvider), httpClientProvider.GetDatabaseDisciplineEditor());
			UpdateDataGridDisciplines();
		}
		private void MenuItemDeleteDiscipline_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Delete(SelectedDiscipline, httpClientProvider.GetDatabaseDisciplineEditor());
			UpdateDataGridDisciplines();
		}

		private void DataGridGroups_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			CommonMethods.WorkWithTables.View(SelectedGroup, httpClientProvider.GetDatabaseGroupReader(), CommonMethods.GetWindow.Group());
		}
		private void MenuItemAddGroup_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Add(CommonMethods.GetWindow.Group(), httpClientProvider.GetDatabaseGroupEditor());
			UpdateDataGridGroups();
		}
		private void MenuItemEditGroup_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Edit(SelectedGroup, httpClientProvider.GetDatabaseGroupReader(), CommonMethods.GetWindow.Group(), httpClientProvider.GetDatabaseGroupEditor());
			UpdateDataGridGroups();
		}
		private void MenuItemDeleteGroup_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Delete(SelectedGroup, httpClientProvider.GetDatabaseGroupEditor());
			UpdateDataGridGroups();
		}

		private void DataGridStudents_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			CommonMethods.WorkWithTables.View(SelectedStudent, httpClientProvider.GetDatabaseStudentReader(), CommonMethods.GetWindow.Student(httpClientProvider));
		}
		private void MenuItemAddStudent_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Add(CommonMethods.GetWindow.Student(httpClientProvider), httpClientProvider.GetDatabaseStudentEditor());
			UpdateDataGridStudents();
		}
		private void MenuItemEditStudent_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Edit(SelectedStudent, httpClientProvider.GetDatabaseStudentReader(), CommonMethods.GetWindow.Student(httpClientProvider), httpClientProvider.GetDatabaseStudentEditor());
			UpdateDataGridStudents();
		}
		private void MenuItemDeleteStudent_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Delete(SelectedStudent, httpClientProvider.GetDatabaseStudentEditor());
			UpdateDataGridStudents();
		}
		private void MenuItemCreateReport_OnClick(object sender, RoutedEventArgs e) {
			if (DataGridStudents.SelectedItem != null)
				new CreateReportWindow(SelectedStudent, httpClientProvider.GetReportsCreator()).ShowDialog();
		}

		private void DataGridUsers_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			CommonMethods.WorkWithTables.View(SelectedUser, httpClientProvider.GetDatabaseUserReader(), CommonMethods.GetWindow.User());
		}
		private void MenuItemAddUser_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Add(CommonMethods.GetWindow.User(), httpClientProvider.GetDatabaseUserEditor());
			UpdateDataGridUsers();
		}
		private void MenuItemEditUser_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Edit(SelectedUser, httpClientProvider.GetDatabaseUserReader(), CommonMethods.GetWindow.User(), httpClientProvider.GetDatabaseUserEditor());
			UpdateDataGridUsers();
		}
		private void MenuItemDeleteUser_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.WorkWithTables.Delete(SelectedUser, httpClientProvider.GetDatabaseUserEditor());
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
			DataGridDisciplines.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(httpClientProvider.GetDatabaseDisciplineReader().GetAllBasedProies);
		}
		private void UpdateDataGridGroups() {
			DataGridGroups.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(httpClientProvider.GetDatabaseGroupReader().GetAllBasedProies);
		}
		private void UpdateDataGridStudents() {
			DataGridStudents.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(httpClientProvider.GetDatabaseStudentReader().GetAllBasedProies);
		}
		private void UpdateDataGridUsers() {
			DataGridUsers.ItemsSource = CommonMethods.SafeRunMethod.WithReturn(httpClientProvider.GetDatabaseUserReader().GetAllBasedProies);
		}
	}
}