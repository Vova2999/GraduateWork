using System;

namespace GraduateWork.Common.Extensions {
	// ReSharper disable UnusedMember.Global

	public static class StringExtensions {
		public static int ToInt(this string line) {
			return int.Parse(line);
		}

		public static DateTime ToDateTime(this string line) {
			return DateTime.Parse(line);
		}

		public static TEnum ToEnum<TEnum>(this string line) {
			return (TEnum)Enum.Parse(typeof(TEnum), line);
		}
	}
}