using System;

namespace GraduateWork.Common.Tables.Attributes {
	public class HeaderColumnAttribute : Attribute {
		public readonly string HeaderColumn;

		public HeaderColumnAttribute(string headerColumn) {
			HeaderColumn = headerColumn;
		}
	}
}