using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Enums {
	// ReSharper disable UnusedMember.Global

	public enum ControlType {
		[NameEnumValue("Экзамен")]
		Exam,
		[NameEnumValue("Государственный экзамен")]
		StateExam,
		[NameEnumValue("Зачет")]
		Credit,
		[NameEnumValue("Дифференцированный зачет")]
		DifferentiatedCredit,
		[NameEnumValue("Курсовая работа")]
		CourseWork,
		[NameEnumValue("Практика")]
		Practice
	}
}