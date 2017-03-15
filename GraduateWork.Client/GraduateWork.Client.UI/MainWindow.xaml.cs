using System.Windows;
using GraduateWork.Client.Client;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Client.UI.TableWindows;
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
			DataGridTableGroups.ItemsSource = httpClient.GetAllGroups();
		}
		private void ButtonUpdateTableDisciplines_OnClick(object sender, RoutedEventArgs e) {
			DataGridTableDisciplines.ItemsSource = httpClient.GetAllDisciplines();
		}
		private void ButtonUpdateTableStudents_OnClick(object sender, RoutedEventArgs e) {
			DataGridTableStudents.ItemsSource = httpClient.GetAllStudents();
		}

		private void AddGroup() {
			var groupWindow = new GroupWindow();
			groupWindow.ShowDialog();
			if (groupWindow.Group == null)
				return;

			if (!httpClient.AddGroup(groupWindow.Group))
				MessageBox.Show("Ошибка при добавлении группы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void EditGroup() {
			var selectedGroup = GetSelectedGroup();
			if (selectedGroup == null) {
				MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var groupWindow = new GroupWindow(selectedGroup);
			groupWindow.ShowDialog();
			if (groupWindow.Group == null)
				return;

			if (!httpClient.EditGroup(selectedGroup, groupWindow.Group))
				MessageBox.Show("Ошибка при изменении группы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void DeleteGroup() {
			var selectedGroup = GetSelectedGroup();
			if (selectedGroup == null) {
				MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (!httpClient.DeleteGroup(selectedGroup))
				MessageBox.Show("Ошибка при добавлении группы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		private void AddDiscipline() {
		}
		private void EditDiscipline() {
		}
		private void DeleteDiscipline() {
		}

		private void AddStudent() {
		}
		private void EditStudent() {
		}
		private void DeleteStudent() {
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
	}
}