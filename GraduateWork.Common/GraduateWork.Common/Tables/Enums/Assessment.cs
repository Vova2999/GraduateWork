using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Enums {
	// ReSharper disable UnusedMember.Global

	public enum Assessment {
		[NameEnumValue("Не указано")]
		None,
		[NameEnumValue("Неудовлетворительно")]
		Bad,
		[NameEnumValue("Удовлетворительно")]
		Satisfactory,
		[NameEnumValue("Хорошо")]
		Good,
		[NameEnumValue("Отлично")]
		Excellent,
		[NameEnumValue("Не зачтено")]
		NotCredited,
		[NameEnumValue("Зачтено")]
		Credited
	}
}