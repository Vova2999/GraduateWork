﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Client.UI.Windows;
using GraduateWork.Client.UI.Windows.Filters;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Client.UI {
	public partial class MainWindow {
		private readonly HttpClientProvider httpClientProvider;
		private readonly ClientUiConfiguration clientUiConfiguration;
		private readonly DisciplineFilterWindow disciplineFilterWindow = new DisciplineFilterWindow();
		private readonly GroupFilterWindow groupFilterWindow = new GroupFilterWindow();
		private readonly StudentFilterWindow studentFilterWindow = new StudentFilterWindow();
		private readonly UserFilterWindow userFilterWindow = new UserFilterWindow();

		private DisciplineBasedProxy SelectedDiscipline => (DisciplineBasedProxy)DataGridDisciplines.SelectedItem;
		private GroupBasedProxy SelectedGroup => (GroupBasedProxy)DataGridGroups.SelectedItem;
		private StudentBasedProxy SelectedStudent => (StudentBasedProxy)DataGridStudents.SelectedItem;
		private UserBasedProxy SelectedUser => (UserBasedProxy)DataGridUsers.SelectedItem;

		public MainWindow() {
			InitializeComponent();
			clientUiConfiguration = LoadClientUiConfiguration();
			httpClientProvider = new HttpClientProvider(clientUiConfiguration.ServerAddress, clientUiConfiguration.TimeoutMs, clientUiConfiguration.UserLogin, clientUiConfiguration.UserPassword);

			DataGridDisciplines.LoadTable(typeof(DisciplineBasedProxy));
			DataGridGroups.LoadTable(typeof(GroupBasedProxy));
			DataGridStudents.LoadTable(typeof(StudentBasedProxy));
			DataGridUsers.LoadTable(typeof(UserBasedProxy));
		}
		private ClientUiConfiguration LoadClientUiConfiguration() {
			var configuration = ClientUiConfiguration.ReadConfiguration();
			TextBoxServerAddress.Text = configuration.ServerAddress;
			TextBoxRequestTimeoutMs.Text = configuration.TimeoutMs.ToString();
			TextBoxUserLogin.Text = configuration.UserLogin;
			PasswordBoxUserPassword.Password = configuration.UserPassword;
			CheckBoxSaveLoginAndPassword.IsChecked = configuration.SaveLoginAndPassword;

			return configuration;
		}

		private void MainWindow_OnClosing(object sender, CancelEventArgs e) {
			var saveLoginAndPassword = CheckBoxSaveLoginAndPassword.IsChecked == true;
			clientUiConfiguration.ServerAddress = httpClientProvider.ServerAddress;
			clientUiConfiguration.TimeoutMs = httpClientProvider.TimeoutMs;
			clientUiConfiguration.UserLogin = saveLoginAndPassword ? httpClientProvider.Login : string.Empty;
			clientUiConfiguration.UserPassword = saveLoginAndPassword ? httpClientProvider.Password : string.Empty;
			clientUiConfiguration.SaveLoginAndPassword = saveLoginAndPassword;

			clientUiConfiguration.WriteConfiguration();

			disciplineFilterWindow.Close();
			groupFilterWindow.Close();
			studentFilterWindow.Close();
			userFilterWindow.Close();
		}

		private void ButtonConnectToServer_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.SafeRunMethod.WithoutReturn(SetServerAddress, "Соединение было успешно установлено");
		}
		private void SetServerAddress() {
			var errors = GetConnectToServerErrors().ToArray();
			if (errors.Any())
				throw new ArgumentException(string.Join("\n", errors));

			httpClientProvider.GetParameretsClient().SetServerAddressAndTimeoutMs(TextBoxServerAddress.Text, TextBoxRequestTimeoutMs.Text.ToInt());
			TextBoxServerAddress.Text = httpClientProvider.ServerAddress;
		}
		private IEnumerable<string> GetConnectToServerErrors() {
			if (CommonMethods.Check.FieldIsEmpty(TextBoxServerAddress))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelServerAddress);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxRequestTimeoutMs))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelRequestTimeoutMs);
			else if (CommonMethods.Check.FieldIsNotNumber(TextBoxRequestTimeoutMs))
				yield return CommonMethods.GenerateMessage.FieldIsNotNumber(LabelRequestTimeoutMs);
			else if (CommonMethods.Check.FieldNumberIsNotPositive(TextBoxRequestTimeoutMs))
				yield return CommonMethods.GenerateMessage.FieldNumberIsNotPositive(LabelRequestTimeoutMs);
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
			disciplineFilterWindow.ShowDialog();
			UpdateDataGridDisciplines();
		}
		private void ButtonGroupFilters_OnClick(object sender, RoutedEventArgs e) {
			groupFilterWindow.ShowDialog();
			UpdateDataGridGroups();
		}
		private void ButtonStudentFilters_OnClick(object sender, RoutedEventArgs e) {
			studentFilterWindow.ShowDialog();
			UpdateDataGridStudents();
		}
		private void ButtonUserFilters_OnClick(object sender, RoutedEventArgs e) {
			userFilterWindow.ShowDialog();
			UpdateDataGridUsers();
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
			DataGridDisciplines.ItemsSource = disciplineFilterWindow.UseFilters
				? CommonMethods.SafeRunMethod.WithReturn(() => httpClientProvider.GetDatabaseDisciplineReader().GetDisciplinesWithUsingFilters(disciplineFilterWindow.DisciplineName, disciplineFilterWindow.ControlType, disciplineFilterWindow.GroupName))
				: CommonMethods.SafeRunMethod.WithReturn(httpClientProvider.GetDatabaseDisciplineReader().GetAllBasedProies);
		}
		private void UpdateDataGridGroups() {
			DataGridGroups.ItemsSource = groupFilterWindow.UseFilters
				? CommonMethods.SafeRunMethod.WithReturn(() => httpClientProvider.GetDatabaseGroupReader().GetGroupsWithUsingFilters(groupFilterWindow.GroupName))
				: CommonMethods.SafeRunMethod.WithReturn(httpClientProvider.GetDatabaseGroupReader().GetAllBasedProies);
		}
		private void UpdateDataGridStudents() {
			DataGridStudents.ItemsSource = studentFilterWindow.UseFilters
				? CommonMethods.SafeRunMethod.WithReturn(() => httpClientProvider.GetDatabaseStudentReader().GetStudentsWithUsingFilters(studentFilterWindow.FirstName, studentFilterWindow.SecondName, studentFilterWindow.ThirdName, studentFilterWindow.DateOfBirth))
				: CommonMethods.SafeRunMethod.WithReturn(httpClientProvider.GetDatabaseStudentReader().GetAllBasedProies);
		}
		private void UpdateDataGridUsers() {
			DataGridUsers.ItemsSource = userFilterWindow.UseFilters
				? CommonMethods.SafeRunMethod.WithReturn(() => httpClientProvider.GetDatabaseUserReader().GetUsersWithUsingFilters(userFilterWindow.UserLogin))
				: CommonMethods.SafeRunMethod.WithReturn(httpClientProvider.GetDatabaseUserReader().GetAllBasedProies);
		}
	}
}