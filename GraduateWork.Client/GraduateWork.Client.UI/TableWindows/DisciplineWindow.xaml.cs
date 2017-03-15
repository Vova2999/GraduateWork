using System;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class DisciplineWindow {
		public DisciplineProxy Discipline { get; private set; }

		public DisciplineWindow(DisciplineProxy discipline = null) {
			InitializeComponent();
			Closed += DisciplineWindow_Closed;
		}
		private void SetDiscipline(DisciplineProxy discipline) {
			if (discipline == null)
				return;

			TextBoxNameOfDiscipline.Text = discipline.NameOfDiscipline;
		}

		private void DisciplineWindow_Closed(object sender, EventArgs e) {
			Discipline = new DisciplineProxy {
				NameOfDiscipline = TextBoxNameOfDiscipline.Text
			};
		}
	}
}