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
				{ typeof(DateTime), GenerateDataTimeColumn },
				{ typeof(DateTime?), GenerateDataTimeColumn }
			};

		public static void LoadTable(this DataGrid dataGrid, Type type) {
			dataGrid.SelectionMode = DataGridSelectionMode.Single;
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
				.Where(t => t.attribute != null && generateColumn.ContainsKey(t.propertyInfo.PropertyType))
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
		private static DataGridColumn GenerateDataTimeColumn(string header, string bindingName) {
			return new DataGridTextColumn {
				Header = header,
				Binding = new Binding(bindingName) {
					StringFormat = "dd.hh.yyyy"
				}
			};
		}

		public static void CreateContextMenuForDatabase(this DataGrid dataGrid, Action add, Action edit, Action delete) {
			dataGrid.ContextMenu = new ContextMenu {
				ItemsSource = new[] {
					CreateMenuItem("Добавить", add),
					CreateMenuItem("Редактировать", edit),
					CreateMenuItem("Удалить", delete)
				}
			};
		}
		private static MenuItem CreateMenuItem(string header, Action action) {
			var menuItem = new MenuItem { Header = header };
			menuItem.Click += (sender, args) => action();

			return menuItem;
		}
	}
}