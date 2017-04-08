using System;

namespace GraduateWork.Common.Tables.Attributes {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedAutoPropertyAccessor.Global

	public class HeaderColumnAttribute : Attribute {
		public string HeaderColumn { get; set; }

		public HeaderColumnAttribute(string headerColumn) {
			HeaderColumn = headerColumn;
		}
	}
}