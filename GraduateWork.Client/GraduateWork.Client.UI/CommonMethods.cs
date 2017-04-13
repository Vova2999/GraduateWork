using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Enums;

namespace GraduateWork.Client.UI {
	public static class CommonMethods {
		public static class Set {
			public static void ReadOnly(TextBox textBox, bool isReadOnly) {
				textBox.IsReadOnly = isReadOnly;
			}

			public static void ReadOnly(CheckBox checkBox, bool isReadOnly) {
				checkBox.IsEnabled = !isReadOnly;
			}

			public static void ReadOnly(ComboBox comboBox, bool isReadOnly) {
				comboBox.IsEnabled = !isReadOnly;
			}

			public static void ReadOnly(DatePicker datePicker, bool isReadOnly) {
				datePicker.IsEnabled = !isReadOnly;
			}

			public static void ReadOnly(DataGrid dataGrid, bool isReadOnly) {
				dataGrid.IsReadOnly = isReadOnly;
			}
		}

		public static class Check {
			public static bool FieldIsEmpty(TextBox textBox) {
				return string.IsNullOrEmpty(textBox.Text);
			}

			public static bool FieldIsEmpty(ComboBox comboBox) {
				return string.IsNullOrEmpty((string)comboBox.SelectedItem);
			}

			public static bool FieldIsNotNumber(TextBox textBox) {
				int result;
				return !int.TryParse(textBox.Text, out result);
			}
		}

		public static class GenerateMessage {
			public static string FieldIsEmpty(Label label) {
				return $"Необходимо заполнить поле '{(string)label.Content}'";
			}

			public static string FieldIsNotNumber(Label label) {
				return $"Поле '{(string)label.Content}' должно быть числом";
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

		public static class WorkWithTables {
			public static void View<TBasedProxy, TExtendedProxy>(TBasedProxy selectedItem, Func<TBasedProxy, TExtendedProxy> getExtendedProxy, Func<TExtendedProxy, bool, Window> getWindow) {
				if (selectedItem == null)
					return;

				var extendedProxy = SafeRunMethod.WithReturn(() => getExtendedProxy(selectedItem));
				if (extendedProxy == null)
					return;

				getWindow(extendedProxy, true).ShowDialog();
			}

			public static void Add<TExtendedProxy, TWindow>(TExtendedProxy defaultExtendedProxy, Func<TExtendedProxy, bool, TWindow> getWindow, Action<TExtendedProxy> addExtendedProxy, Func<TWindow, TExtendedProxy> getExtendedProxyFromWindow) where TWindow : Window {
				var window = getWindow(defaultExtendedProxy, false);
				if (window.ShowDialog() != true)
					return;

				SafeRunMethod.WithoutReturn(() => addExtendedProxy(getExtendedProxyFromWindow(window)));
			}

			public static void Edit<TBasedProxy, TExtendedProxy, TWindow>(TBasedProxy selectedItem, Func<TBasedProxy, TExtendedProxy> getExtendedProxy, Func<TExtendedProxy, bool, TWindow> getWindow, Action<TExtendedProxy, TExtendedProxy> editExtendedProxy, Func<TWindow, TExtendedProxy> getExtendedProxyFromWindow) where TWindow : Window {
				if (selectedItem == null)
					return;

				var oldProxy = SafeRunMethod.WithReturn(() => getExtendedProxy(selectedItem));
				if (oldProxy == null)
					return;

				var window = getWindow(oldProxy, false);
				if (window.ShowDialog() != true)
					return;

				SafeRunMethod.WithoutReturn(() => editExtendedProxy(oldProxy, getExtendedProxyFromWindow(window)));
			}

			public static void Delete<TBasedProxy, TExtendedProxy>(TBasedProxy selectedItem, Func<TBasedProxy, TExtendedProxy> getExtendedProxy, Action<TExtendedProxy> deleteExtendedProxy) {
				if (selectedItem == null)
					return;

				var extendedProxy = SafeRunMethod.WithReturn(() => getExtendedProxy(selectedItem));
				if (extendedProxy == null)
					return;

				SafeRunMethod.WithoutReturn(() => deleteExtendedProxy(extendedProxy));
			}
		}

		public static class CloseWindow {
			public static void TrueDialogResult<TWindow>(TWindow window) where TWindow : Window, IProxyWindow {
				if (window.IsReadOnly) {
					window.Close();
					return;
				}

				var errors = window.GetErrors().ToArray();
				if (errors.Any())
					ShowMessageBox.Error(string.Join("\n", errors));
				else {
					window.WriteProxy();
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

		public static class Enum {
			private static readonly Dictionary<ControlType, string> controlTypeNames = GetNameEnumValues<ControlType>();
			private static readonly Dictionary<string, ControlType> controlTypeValues = GetValueEnumNames(controlTypeNames);
			private static readonly Dictionary<Assessment, string> assessmentNames = GetNameEnumValues<Assessment>();
			private static readonly Dictionary<string, Assessment> assessmentValues = GetValueEnumNames(assessmentNames);

			private static Dictionary<TEnum, string> GetNameEnumValues<TEnum>() {
				return typeof(TEnum)
					.GetEnumValues()
					.Cast<TEnum>()
					.ToDictionary(value => value,
						value => typeof(TEnum)
							.GetField(value.ToString())
							.GetCustomAttribute<NameEnumValueAttribute>()
							.NameEnumValue);
			}
			private static Dictionary<string, TEnum> GetValueEnumNames<TEnum>(Dictionary<TEnum, string> names) {
				return names.ToDictionary(keyValue => keyValue.Value, keyValue => keyValue.Key);
			}

			public static string[] GetControlTypeNames() {
				return controlTypeValues.Keys.ToArray();
			}
			public static string GetControlTypeName(ControlType controlType) {
				return controlTypeNames[controlType];
			}
			public static ControlType GetControlTypeValue(string controlTypeName) {
				return controlTypeValues[controlTypeName];
			}

			public static string[] GetAssessmentNames() {
				return assessmentValues.Keys.ToArray();
			}
			public static string GetAssessmentName(Assessment assessment) {
				return assessmentNames[assessment];
			}
			public static Assessment GetAssessmentValue(string assessmentName) {
				return assessmentValues[assessmentName];
			}
		}
	}
}