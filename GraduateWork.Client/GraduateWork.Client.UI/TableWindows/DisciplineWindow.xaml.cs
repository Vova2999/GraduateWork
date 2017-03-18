using System.Windows;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class DisciplineWindow {
		public DisciplineProxy Discipline { get; private set; }

		public DisciplineWindow(DisciplineProxy discipline = null) {
			InitializeComponent();
			SetDiscipline(discipline);
		}
		private void SetDiscipline(DisciplineProxy discipline) {
			if (discipline == null)
				return;

			TextBoxNameOfDiscipline.Text = discipline.NameOfDiscipline;
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			Discipline = new DisciplineProxy {
				NameOfDiscipline = TextBoxNameOfDiscipline.Text
			};
			Close();
		}
	}
}