using System.Windows;
using GraduateWork.Client.UI.TableWindows;

namespace GraduateWork.Client.UI {
	public partial class MainWindow {
		private void AddGroup() {
			var groupWindow = new GroupWindow();
			groupWindow.ShowDialog();
			if (groupWindow.Group == null)
				return;

			RunOrShowMessage(() => httpClient.AddGroup(groupWindow.Group));
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

			RunOrShowMessage(() => httpClient.EditGroup(selectedGroup, groupWindow.Group));
		}
		private void DeleteGroup() {
			var selectedGroup = GetSelectedGroup();
			if (selectedGroup == null) {
				MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			RunOrShowMessage(() => httpClient.DeleteGroup(selectedGroup));
		}

		private void AddDiscipline() {
			var disciplineWindow = new DisciplineWindow();
			disciplineWindow.ShowDialog();
			if (disciplineWindow.Discipline == null)
				return;

			RunOrShowMessage(() => httpClient.AddDiscipline(disciplineWindow.Discipline));
		}
		private void EditDiscipline() {
			var selectedDiscipline = GetSelectedDiscipline();
			if (selectedDiscipline == null) {
				MessageBox.Show("Выберите предмет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var groupWindow = new DisciplineWindow(selectedDiscipline);
			groupWindow.ShowDialog();
			if (groupWindow.Discipline == null)
				return;

			RunOrShowMessage(() => httpClient.EditDiscipline(selectedDiscipline, groupWindow.Discipline));
		}
		private void DeleteDiscipline() {
			var selectedDiscipline = GetSelectedDiscipline();
			if (selectedDiscipline == null) {
				MessageBox.Show("Выберите предмет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			RunOrShowMessage(() => httpClient.DeleteDiscipline(selectedDiscipline));
		}

		private void AddStudent() {
			var studentWindow = new StudentWindow(httpClient.GetAllGroups(), httpClient.GetAllDisciplines());
			studentWindow.ShowDialog();
			if (studentWindow.Student == null)
				return;

			RunOrShowMessage(() => httpClient.AddStudent(studentWindow.Student));
		}
		private void EditStudent() {
			var selectedStudent = GetSelectedStudent();
			if (selectedStudent == null) {
				MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var studentWindow = new StudentWindow(httpClient.GetAllGroups(), httpClient.GetAllDisciplines(), selectedStudent);
			studentWindow.ShowDialog();
			if (studentWindow.Student == null)
				return;

			RunOrShowMessage(() => httpClient.EditStudent(selectedStudent, studentWindow.Student));
		}
		private void DeleteStudent() {
			var selectedStudent = GetSelectedStudent();
			if (selectedStudent == null) {
				MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			RunOrShowMessage(() => httpClient.DeleteStudent(selectedStudent));
		}
	}
}