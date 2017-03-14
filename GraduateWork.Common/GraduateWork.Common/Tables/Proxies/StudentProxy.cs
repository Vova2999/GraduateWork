using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies {
	public class StudentProxy {
		[HeaderColumn("Имя")]
		public string FirstName { get; set; }

		[HeaderColumn("Фамилия")]
		public string SecondName { get; set; }

		[HeaderColumn("Отчество")]
		public string ThirdName { get; set; }

		[HeaderColumn("Дата поступления")]
		public DateTime YearOfReceipt { get; set; }

		[HeaderColumn("Дата отчисления")]
		public DateTime? YearOfDeduction { get; set; }

		[HeaderColumn("Группа")]
		public string NameOfGroup { get; set; }

		[HeaderColumn("Оценки по дисциплинам")]
		public AssessmentByDiscipline[] AssessmentByDisciplines { get; set; }
	}

	public class AssessmentByDiscipline {
		public string NameOfDiscipline { get; set; }
		public Assessment Assessment { get; set; }
	}

	public enum Assessment {
		Excellent = 5,
		Good = 4,
		Satisfactory = 3
	}
}