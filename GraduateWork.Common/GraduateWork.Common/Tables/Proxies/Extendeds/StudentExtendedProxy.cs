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
		[HeaderColumn("������� ����������� ��������� �� �����������")]
		public string PreviousEducationName { get; set; }

		[HeaderColumn("��� ������ ����������� ��������� �� �����������")]
		public int PreviousEducationYear { get; set; }

		[HeaderColumn("����� �����������")]
		public string EnrollmentName { get; set; }

		[HeaderColumn("��� �����������")]
		public int EnrollmentYear { get; set; }

		[HeaderColumn("����� ����������")]
		public string DeductionName { get; set; }

		[HeaderColumn("��� ����������")]
		public int DeductionYear { get; set; }

		[HeaderColumn("���� �������")]
		public string DiplomaTopic { get; set; }

		[HeaderColumn("������ �������")]
		public int DiplomaAssessment { get; set; }

		[HeaderColumn("���� ������")]
		public DateTime ProtectionDate { get; set; }

		[HeaderColumn("����� ���������")]
		public string ProtocolNumber { get; set; }

		[HeaderColumn("��������������� �����")]
		public string RegistrationNumber { get; set; }

		[HeaderColumn("���� �����������")]
		public DateTime RegistrationDate { get; set; }

		[HeaderColumn("������")]
		public GroupBasedProxy Group { get; set; }

		[HeaderColumn("������ �� �����������")]
		public AssessmentByDiscipline[] AssessmentByDisciplines { get; set; }
	}

	public class AssessmentByDiscipline {
		public string NameOfDiscipline { get; set; }
		public int? Assessment { get; set; }
	}
}