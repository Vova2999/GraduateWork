using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class StudentDisciplinesWindow {
		private class AssessmentByDisciplineForWindow {
			public string NameOfDiscipline { get; set; }
			public string Assessment { get; set; }
		}

		private readonly AssessmentByDisciplineForWindow[] assessmentByDisciplinesForWindow;
		public AssessmentByDiscipline[] AssessmentByDisciplines {
			get {
				return assessmentByDisciplinesForWindow
					.Where(assessmentByDiscipline => !string.IsNullOrEmpty(assessmentByDiscipline.Assessment))
					.Select(assessmentByDiscipline => new AssessmentByDiscipline {
						NameOfDiscipline = assessmentByDiscipline.NameOfDiscipline,
						Assessment = (Assessment)Enum.Parse(typeof(Assessment), assessmentByDiscipline.Assessment)
					}).ToArray();
			}
		}

		public StudentDisciplinesWindow(DisciplineProxy[] disciplines, AssessmentByDiscipline[] assessmentByDisciplines) {
			InitializeComponent();

			DataGridDisciplines.ItemsSource = assessmentByDisciplinesForWindow = CraeteTable(disciplines);
			SetAssessments(assessmentByDisciplines);
		}
		private AssessmentByDisciplineForWindow[] CraeteTable(DisciplineProxy[] disciplines) {
			DataGridDisciplines.Columns.Add(new DataGridTextColumn {
				Header = typeof(DisciplineProxy)
					.GetProperty("NameOfDiscipline")
					.GetCustomAttribute<HeaderColumnAttribute>()
					.HeaderColumn,
				Binding = new Binding("NameOfDiscipline")
			});
			DataGridDisciplines.Columns.Add(new DataGridComboBoxColumn {
				Header = "Оценка",
				ItemsSource = new[] { string.Empty }.Concat(typeof(Assessment).GetEnumNames()),
				SelectedItemBinding = new Binding("Assessment")
			});

			return disciplines.Select(discipline => new AssessmentByDisciplineForWindow {
				NameOfDiscipline = discipline.NameOfDiscipline,
				Assessment = string.Empty
			}).ToArray();
		}
		private void SetAssessments(AssessmentByDiscipline[] assessmentByDisciplines) {
			if (assessmentByDisciplines == null)
				return;

			foreach (var assessmentByDiscipline in assessmentByDisciplines)
				assessmentByDisciplinesForWindow.First(x => x.NameOfDiscipline == assessmentByDiscipline.NameOfDiscipline).Assessment =
					assessmentByDiscipline.Assessment.ToString();
		}
		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}