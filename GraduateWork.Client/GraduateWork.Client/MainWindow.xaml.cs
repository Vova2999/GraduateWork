using System;
using System.Windows;
using GraduateWork.Client.Extensions;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client {
	public partial class MainWindow {
		public MainWindow() {
			InitializeComponent();

			DataGridTableGroups.LoadTable(typeof(GroupProxy));
			DataGridTableDisciplines.LoadTable(typeof(DisciplineProxy));
			DataGridTableStudents.LoadTable(typeof(StudentProxy));
		}

		private void ButtonUpdateTableGroups_OnClick(object sender, RoutedEventArgs e) {
			throw new NotImplementedException();
		}
		private void ButtonUpdateTableDisciplines_OnClick(object sender, RoutedEventArgs e) {
			throw new NotImplementedException();
		}
		private void ButtonUpdateTableStudents_OnClick(object sender, RoutedEventArgs e) {
			throw new NotImplementedException();
		}
	}
}