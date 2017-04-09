﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Client.UI.Extensions {
	public static class DataGridExtensions {
		private static readonly Dictionary<Type, Func<string, string, DataGridColumn>> generateColumn =
			new Dictionary<Type, Func<string, string, DataGridColumn>> {
				{ typeof(int), GenerateTextColumn },
				{ typeof(string), GenerateTextColumn },
				{ typeof(DateTime), GenerateDataTimeColumn },
				{ typeof(DateTime?), GenerateDataTimeColumn },
				{ typeof(GroupBasedProxy), GenerateGroupColumn }
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
					propertyInfo.Name,
					propertyInfo.PropertyType,
					Attribute = propertyInfo.GetCustomAttributes<HeaderColumnAttribute>().FirstOrDefault()
				})
				.Where(x => x.Attribute != null && generateColumn.ContainsKey(x.PropertyType))
				.Select(x => generateColumn[x.PropertyType](x.Attribute.HeaderColumn, x.Name))
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
		private static DataGridColumn GenerateGroupColumn(string header, string bindingName) {
			return new DataGridTextColumn {
				Header = header,
				Binding = new Binding(bindingName + ".GroupName")
			};
		}
	}
}