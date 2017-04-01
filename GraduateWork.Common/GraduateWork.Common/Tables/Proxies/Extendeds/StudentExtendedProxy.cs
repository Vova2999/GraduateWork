using System;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	// ReSharper disable UnusedMember.Global

	public class StudentExtendedProxy : StudentBasedProxy {
		[HeaderColumn("Назваие предыдущего документа об образовании")]
		public string PreviousEducationName { get; set; }

		[HeaderColumn("Год выдачи предыдущего документа об образовании")]
		public int PreviousEducationYear { get; set; }

		[HeaderColumn("Место поступления")]
		public string EnrollmentName { get; set; }

		[HeaderColumn("Год поступления")]
		public int EnrollmentYear { get; set; }

		[HeaderColumn("Место отчисления")]
		public string DeductionName { get; set; }

		[HeaderColumn("Год отчисления")]
		public int DeductionYear { get; set; }

		[HeaderColumn("Тема диплома")]
		public string DiplomaTopic { get; set; }

		[HeaderColumn("Оценка диплома")]
		public int DiplomaAssessment { get; set; }

		[HeaderColumn("Дата защиты")]
		public DateTime ProtectionDate { get; set; }

		[HeaderColumn("Номер протокола")]
		public string ProtocolNumber { get; set; }

		[HeaderColumn("Регистрационный номер")]
		public string RegistrationNumber { get; set; }

		[HeaderColumn("Дата регистрации")]
		public DateTime RegistrationDate { get; set; }

		[HeaderColumn("Группа")]
		public GroupBasedProxy Group { get; set; }

		[HeaderColumn("Оценки по дисциплинам")]
		public AssessmentByDiscipline[] AssessmentByDisciplines { get; set; }
	}

	public class AssessmentByDiscipline {
		public string NameOfDiscipline { get; set; }
		public int? Assessment { get; set; }
	}
}