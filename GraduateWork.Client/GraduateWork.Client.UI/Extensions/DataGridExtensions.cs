using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Client.UI.Extensions {
	public static class DataGridExtensions {
		private static readonly Dictionary<Type, Func<string, string, DataGridColumn>> generateColumn =
			new Dictionary<Type, Func<string, string, DataGridColumn>> {
				{ typeof(int), GenerateTextColumn },
				{ typeof(string), GenerateTextColumn },
				{ typeof(DateTime), GenerateDataColumn },
				{ typeof(DateTime?), GenerateDataColumn },
				{ typeof(string[]), (header, bindingName) => null }
			};

		public static void LoadTable(this DataGrid dataGrid, Type type) {
			dataGrid.AutoGenerateColumns = false;
			dataGrid.CanUserAddRows = false;
			dataGrid.CanUserDeleteRows = false;
			dataGrid.CanUserReorderColumns = false;
			dataGrid.IsReadOnly = true;
			dataGrid.ItemsSource = null;
			dataGrid.Columns.Clear();

			var columns = type.GetProperties()
				.Select(propertyInfo => new {
					propertyInfo,
					attribute = propertyInfo.GetCustomAttributes<HeaderColumnAttribute>().FirstOrDefault()
				})
				.Where(t => t.attribute != null)
				.Select(t => generateColumn[t.propertyInfo.PropertyType](t.attribute.HeaderColumn, t.propertyInfo.Name))
				.Where(column => column != null)
				.ToArray();
			columns.Last().Width = new DataGridLength(1, DataGridLengthUnitType.Star);

			foreach (var column in columns)
				dataGrid.Columns.Add(column);
		}

		private static DataGridColumn GenerateTextColumn(string header, string bindingName) {
			return new DataGridTextColumn {
				Header = header,
				Binding = new Binding(bindingName)
			};
		}
		private static DataGridColumn GenerateDataColumn(string header, string bindingName) {
			return new DataGridTextColumn {
				Header = header,
				Binding = new Binding(bindingName) {
					StringFormat = "dd.hh.yyyy"
				}
			};
		}
	}
}