using System;
using System.Windows;
using GraduateWork.Client.Client;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.UI {
	public partial class MainWindow {
		private readonly IHttpClient httpClient = new HttpClient();

		public MainWindow() {
			InitializeComponent();

			DataGridTableGroups.LoadTable(typeof(GroupProxy));
			DataGridTableDisciplines.LoadTable(typeof(DisciplineProxy));
			DataGridTableStudents.LoadTable(typeof(StudentProxy));

			DataGridTableGroups.CreateContextMenuForDatabase(AddGroup, EditGroup, DeleteGroup);
			DataGridTableDisciplines.CreateContextMenuForDatabase(AddDiscipline, EditDiscipline, DeleteDiscipline);
			DataGridTableStudents.CreateContextMenuForDatabase(AddStudent, EditStudent, DeleteStudent);
		}

		private void ButtonUpdateTableGroups_OnClick(object sender, RoutedEventArgs e) {
			DataGridTableGroups.ItemsSource = GetOrShowMessage(() => httpClient.GetAllGroups());
		}
		private void ButtonUpdateTableDisciplines_OnClick(object sender, RoutedEventArgs e) {
			DataGridTableDisciplines.ItemsSource = GetOrShowMessage(() => httpClient.GetAllDisciplines());
		}
		private void ButtonUpdateTableStudents_OnClick(object sender, RoutedEventArgs e) {
			DataGridTableStudents.ItemsSource = GetOrShowMessage(() => httpClient.GetAllStudents());
		}

		private GroupProxy GetSelectedGroup() {
			return (GroupProxy)DataGridTableGroups.SelectedItem;
		}
		private DisciplineProxy GetSelectedDiscipline() {
			return (DisciplineProxy)DataGridTableDisciplines.SelectedItem;
		}
		private StudentProxy GetSelectedStudent() {
			return (StudentProxy)DataGridTableStudents.SelectedItem;
		}

		private TKey GetOrShowMessage<TKey>(Func<TKey> get) {
			try {
				return get();
			}
			catch (Exception exception) {
				MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return default(TKey);
			}
		}
		private void RunOrShowMessage(Action run) {
			try {
				run();
			}
			catch (Exception exception) {
				MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}