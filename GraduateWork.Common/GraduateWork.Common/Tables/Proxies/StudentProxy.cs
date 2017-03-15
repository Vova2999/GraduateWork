using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies {
	public class StudentProxy {
		[HeaderColumn("���")]
		public string FirstName { get; set; }

		[HeaderColumn("�������")]
		public string SecondName { get; set; }

		[HeaderColumn("��������")]
		public string ThirdName { get; set; }

		[HeaderColumn("���� �����������")]
		public DateTime DateOfReceipt { get; set; }

		[HeaderColumn("���� ����������")]
		public DateTime? DateOfDeduction { get; set; }

		[HeaderColumn("������")]
		public string NameOfGroup { get; set; }

		[HeaderColumn("������ �� �����������")]
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