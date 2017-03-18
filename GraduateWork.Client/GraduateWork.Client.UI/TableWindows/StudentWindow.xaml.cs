using System.Linq;
using System.Windows;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class StudentWindow {
		private readonly DisciplineProxy[] disciplines;
		private AssessmentByDiscipline[] assessmentByDisciplines;
		public StudentProxy Student { get; private set; }

		public StudentWindow(GroupProxy[] groups, DisciplineProxy[] disciplines, StudentProxy student = null) {
			InitializeComponent();
			ComboBoxNameOfGroup.ItemsSource = groups.Select(group => group.NameOfGroup);

			SetStudent(student);

			this.disciplines = disciplines;
			assessmentByDisciplines = student?.AssessmentByDisciplines;
		}
		private void SetStudent(StudentProxy student) {
			if (student == null)
				return;

			TextBoxFirstName.Text = student.FirstName;
			TextBoxSecondName.Text = student.SecondName;
			TextBoxThirdName.Text = student.ThirdName;
			DatePickerDateOfReceipt.SelectedDate = student.DateOfReceipt;
			DatePickerDateOfDeduction.SelectedDate = student.DateOfDeduction;
			ComboBoxNameOfGroup.Text = student.NameOfGroup;
		}

		private void ButtonDisciplines_OnClick(object sender, RoutedEventArgs e) {
			var studentDisciplinesWindow = new StudentDisciplinesWindow(disciplines, assessmentByDisciplines);
			studentDisciplinesWindow.ShowDialog();

			assessmentByDisciplines = studentDisciplinesWindow.AssessmentByDisciplines;
		}
		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			if (DatePickerDateOfReceipt.SelectedDate == null)
				return;

			Student = new StudentProxy {
				FirstName = TextBoxFirstName.Text,
				SecondName = TextBoxSecondName.Text,
				ThirdName = TextBoxThirdName.Text,
				DateOfReceipt = DatePickerDateOfReceipt.SelectedDate.Value,
				DateOfDeduction = DatePickerDateOfDeduction.SelectedDate,
				NameOfGroup = ComboBoxNameOfGroup.Text,
				AssessmentByDisciplines = assessmentByDisciplines
			};
			Close();
		}
	}
}