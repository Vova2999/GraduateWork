using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GraduateWork.Client.UI {
	public static class CommonMethods {
		public static class Set {
			public static void ReadOnly(TextBox textBox, bool isReadOnly) {
				textBox.IsReadOnly = isReadOnly;
			}

			public static void ReadOnly(CheckBox checkBox, bool isReadOnly) {
				checkBox.IsEnabled = !isReadOnly;
			}
		}

		public static class Check {
			public static bool FieldIsEmpty(TextBox textBox) {
				return string.IsNullOrEmpty(textBox.Text);
			}
		}

		public static class GenerateMessage {
			public static string FieldIsEmpty(Label label) {
				return $"Необходимо заполнить поле '{(string)label.Content}'";
			}
		}

		public static class ShowMessageBox {
			public static void Information(string successfulMessage) {
				MessageBox.Show(successfulMessage, string.Empty, MessageBoxButton.OK, MessageBoxImage.Information);
			}
			public static void Error(string exceptionMessage) {
				MessageBox.Show(exceptionMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public static class CloseWindow {
			public static void TrueDialogResult(Window window, bool isReadOnly, IEnumerable<string> errors, Action actionBeforeClose) {
				if (isReadOnly)
					window.Close();

				var arrayErrors = errors.ToArray();
				if (arrayErrors.Any())
					ShowMessageBox.Error(string.Join("\n", arrayErrors));
				else {
					actionBeforeClose();
					window.DialogResult = true;
					window.Close();
				}
			}

			public static void FalseDialogResult(Window window) {
				window.DialogResult = false;
				window.Close();
			}
		}

		public static class SafeRunMethod {
			public static TKey WithReturn<TKey>(Func<TKey> action, string successfulMessage = null) {
				var result = default(TKey);
				RunMethod(() => { result = action(); }, successfulMessage);
				return result;
			}

			public static void WithoutReturn(Action action, string successfulMessage = null) {
				RunMethod(action, successfulMessage);
			}

			private static void RunMethod(Action action, string successfulMessage) {
				try {
					action();

					if (!string.IsNullOrEmpty(successfulMessage))
						ShowMessageBox.Information(successfulMessage);
				}
				catch (Exception exception) {
					ShowMessageBox.Error(exception.Message);
				}
			}
		}
	}
}