using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI {
	public partial class CreateReportWindow {
		private readonly StudentExtendedProxy student;
		private readonly Dictionary<string, Func<StudentExtendedProxy, FileWithContent>> reportCreators;

		public CreateReportWindow(StudentExtendedProxy student, IReportsCreator reportsCreator) {
			InitializeComponent();
			this.student = student;

			reportCreators = CreateReportCreators(reportsCreator);
			ComboBoxSelectedReport.ItemsSource = reportCreators.Keys;
		}
		private Dictionary<string, Func<StudentExtendedProxy, FileWithContent>> CreateReportCreators(IReportsCreator reportsCreator) {
			return new Dictionary<string, Func<StudentExtendedProxy, FileWithContent>> {
				{ "Академ", reportsCreator.CreateAcadem },
				{ "Диплом", reportsCreator.CreateDiploma },
				{ "Приложение", reportsCreator.CreateDiplomaSupplement }
			};
		}

		private IEnumerable<string> GetErrors() {
			if (ComboBoxSelectedReport.SelectedItem == null)
				yield return "Выберите отчет";

			if (CommonMethods.Check.FieldIsEmpty(TextBoxPath))
				yield return "Выберите место сохранения отчета";
			else if (CommonMethods.Check.DirectoryNotExists(TextBoxPath))
				yield return "Выбранная директория не существует";
		}

		private void ButtonSelectFolder_OnClick(object sender, RoutedEventArgs e) {
			var folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				TextBoxPath.Text = folderBrowserDialog.SelectedPath;
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			var errors = GetErrors().ToArray();
			if (errors.Any()) {
				CommonMethods.ShowMessageBox.Error(string.Join("\n", errors));
				return;
			}

			var report = reportCreators[(string)ComboBoxSelectedReport.SelectedItem](student);
			File.WriteAllBytes(Path.Combine(TextBoxPath.Text, report.FileName), report.Content);
			Close();
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}