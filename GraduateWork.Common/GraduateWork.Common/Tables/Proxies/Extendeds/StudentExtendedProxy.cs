using System;
using System.Linq;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	// ReSharper disable UnusedMember.Global

	public class StudentExtendedProxy : StudentBasedProxy {
		[HeaderColumn("Название предыдущего документа об образовании")]
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
		public Assessment DiplomaAssessment { get; set; }

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

		public StudentExtendedProxy GetExtendedClone() {
			var clone = GetClone<StudentExtendedProxy>();
			clone.PreviousEducationName = PreviousEducationName;
			clone.PreviousEducationYear = PreviousEducationYear;
			clone.EnrollmentName = EnrollmentName;
			clone.EnrollmentYear = EnrollmentYear;
			clone.DeductionName = DeductionName;
			clone.DeductionYear = DeductionYear;
			clone.DiplomaTopic = DiplomaTopic;
			clone.DiplomaAssessment = DiplomaAssessment;
			clone.ProtectionDate = ProtectionDate;
			clone.ProtocolNumber = ProtocolNumber;
			clone.RegistrationNumber = RegistrationNumber;
			clone.RegistrationDate = RegistrationDate;
			clone.Group = Group.GetBasedClone();
			clone.AssessmentByDisciplines = AssessmentByDisciplines
				.Select(assessmentByDiscipline => assessmentByDiscipline.GetClone())
				.ToArray();

			return clone;
		}
	}

	public class AssessmentByDiscipline {
		[HeaderColumn("Название дисциплины")]
		public string NameOfDiscipline { get; set; }

		[HeaderColumn("Тип дисциплины")]
		public ControlType ControlType { get; set; }

		[HeaderColumn("Оценка")]
		public Assessment Assessment { get; set; }

		public override bool Equals(object obj) {
			var that = obj as AssessmentByDiscipline;
			return that != null && string.Equals(NameOfDiscipline, that.NameOfDiscipline, StringComparison.InvariantCultureIgnoreCase);
		}
		public override int GetHashCode() {
			return NameOfDiscipline?.GetHashCode() ?? 0;
		}

		public AssessmentByDiscipline GetClone() {
			return new AssessmentByDiscipline {
				NameOfDiscipline = NameOfDiscipline,
				ControlType = ControlType,
				Assessment = Assessment
			};
		}
	}
}