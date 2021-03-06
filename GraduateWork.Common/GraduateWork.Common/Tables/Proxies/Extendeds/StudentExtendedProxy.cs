using System;
using System.Linq;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedMember.Global

	public class StudentExtendedProxy : StudentBasedProxy {
		[HeaderColumn("�������� ����������� ��������� �� �����������")]
		public string PreviousEducationName { get; set; }

		[HeaderColumn("��� ������ ����������� ��������� �� �����������")]
		public int PreviousEducationYear { get; set; }

		[HeaderColumn("����� �����������")]
		public string EnrollmentName { get; set; }

		[HeaderColumn("��� �����������")]
		public int EnrollmentYear { get; set; }

		[HeaderColumn("����� ����������")]
		public string ExpulsionName { get; set; }

		[HeaderColumn("��� ����������")]
		public int ExpulsionYear { get; set; }

		[HeaderColumn("���� ������� ����������")]
		public DateTime ExpulsionOrderDate { get; set; }

		[HeaderColumn("����� ������� ����������")]
		public int ExpulsionOrderNumber { get; set; }

		[HeaderColumn("���� �������")]
		public string DiplomaTopic { get; set; }

		[HeaderColumn("������ �������")]
		public Assessment DiplomaAssessment { get; set; }

		[HeaderColumn("���� ������")]
		public DateTime ProtectionDate { get; set; }

		[HeaderColumn("����� ���������")]
		public string ProtocolNumber { get; set; }

		[HeaderColumn("��������������� �����")]
		public string RegistrationNumber { get; set; }

		[HeaderColumn("���� �����������")]
		public DateTime RegistrationDate { get; set; }

		[HeaderColumn("�������� ������")]
		public string GroupName { get; set; }

		[HeaderColumn("������ �� �����������")]
		public AssessmentByDiscipline[] AssessmentByDisciplines { get; set; }

		public StudentExtendedProxy GetExtendedClone() {
			var clone = GetClone<StudentExtendedProxy>();
			clone.PreviousEducationName = PreviousEducationName;
			clone.PreviousEducationYear = PreviousEducationYear;
			clone.EnrollmentName = EnrollmentName;
			clone.EnrollmentYear = EnrollmentYear;
			clone.ExpulsionName = ExpulsionName;
			clone.ExpulsionYear = ExpulsionYear;
			clone.ExpulsionOrderDate = ExpulsionOrderDate;
			clone.ExpulsionOrderNumber = ExpulsionOrderNumber;
			clone.DiplomaTopic = DiplomaTopic;
			clone.DiplomaAssessment = DiplomaAssessment;
			clone.ProtectionDate = ProtectionDate;
			clone.ProtocolNumber = ProtocolNumber;
			clone.RegistrationNumber = RegistrationNumber;
			clone.RegistrationDate = RegistrationDate;
			clone.GroupName = GroupName;
			clone.AssessmentByDisciplines = AssessmentByDisciplines
				.Select(assessmentByDiscipline => assessmentByDiscipline.GetClone())
				.ToArray();

			return clone;
		}
	}

	public class AssessmentByDiscipline {
		[HeaderColumn("�������� ����������")]
		public string NameOfDiscipline { get; set; }

		[HeaderColumn("��� ����������")]
		public ControlType ControlType { get; set; }

		[HeaderColumn("������")]
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