using System;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class StudentWindow {
		public StudentProxy Student { get; private set; }

		public StudentWindow(StudentProxy student = null) {
			InitializeComponent();
			Closed += StudentWindow_Closed;

			SetStudent(student);
		}
		private void SetStudent(StudentProxy student) {
			if (student == null)
				return;

			TextBoxFirstName.Text = student.FirstName;
			TextBoxSecondName.Text = student.SecondName;
			TextBoxThirdName.Text = student.ThirdName;
		}

		private void StudentWindow_Closed(object sender, EventArgs e) {
			Student = new StudentProxy {
				FirstName = TextBoxFirstName.Text,
				SecondName = TextBoxSecondName.Text,
				ThirdName = TextBoxThirdName.Text,
				DateOfReceipt = DatePickerDateOfReceipt.DisplayDate,
				DateOfDeduction = DatePickerDateOfDeduction.DisplayDate,
				NameOfGroup = TextBoxNameOfGroup.Text
			};
		}
	}
}