using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable UnusedMember.Global

	public class DisciplineExtendedProxy : DisciplineBasedProxy {
		[HeaderColumn("Тип дисциплины")]
		public ControlType ControlType { get; set; }

		[HeaderColumn("Всего часов")]
		public int TotalHours { get; set; }

		[HeaderColumn("Аудиторных часов")]
		public int ClassHours { get; set; }
	}

	public enum ControlType {
		Exam,
		StateExam,
		Credit,
		DifferentiatedCredit,
		CourseWork,
		Practice
	}
}