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
		}

		private void ButtonUpdateTableGroups_OnClick(object sender, RoutedEventArgs e) {
			throw new NotImplementedException();
		}
		private void ButtonUpdateTableDisciplines_OnClick(object sender, RoutedEventArgs e) {
			throw new NotImplementedException();
		}
		private void ButtonUpdateTableStudents_OnClick(object sender, RoutedEventArgs e) {
			DataGridTableStudents.ItemsSource = httpClient.GetAllStudents();
		}
	}
}