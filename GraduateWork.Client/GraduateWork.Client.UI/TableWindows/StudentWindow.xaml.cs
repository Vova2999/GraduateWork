using System;
using System.Collections.Generic;
using System.Windows;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class StudentWindow : IProxyWindow {
		public readonly StudentExtendedProxy Student;
		public bool IsReadOnly { get; }

		public StudentWindow(StudentExtendedProxy student, bool isReadOnly) {
			InitializeComponent();

			Student = student?.GetExtendedClone() ?? new StudentExtendedProxy();
			IsReadOnly = isReadOnly;

			DataGridAssessmentByDisciplines.LoadTable(typeof(AssessmentByDiscipline));

			SetGroupFields();
			SetReadOnly();
		}
		private void SetGroupFields() {
		}
		private void SetReadOnly() {
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.TrueDialogResult(this);
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.FalseDialogResult(this);
		}

		public IEnumerable<string> GetErrors() {
			throw new NotImplementedException();
		}
		public void WriteProxy() {
			throw new NotImplementedException();
		}
	}
}