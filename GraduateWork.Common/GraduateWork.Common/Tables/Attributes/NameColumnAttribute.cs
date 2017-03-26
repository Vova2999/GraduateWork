using System;

namespace GraduateWork.Common.Tables.Attributes {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NotAccessedField.Global

	public class HeaderColumnAttribute : Attribute {
		public readonly string HeaderColumn;

		public HeaderColumnAttribute(string headerColumn) {
			HeaderColumn = headerColumn;
		}
	}
}