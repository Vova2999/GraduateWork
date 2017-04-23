using System;

namespace GraduateWork.Common.Tables.Attributes {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

	public class NameEnumValueAttribute : Attribute {
		public string NameEnumValue { get; set; }

		public NameEnumValueAttribute(string nameEnumValue) {
			NameEnumValue = nameEnumValue;
		}
	}
}