using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	// ReSharper disable UnusedMember.Global

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

		public override bool Equals(object obj) {
			var that = obj as StudentProxy;
			return that != null && FirstName == that.FirstName && SecondName == that.SecondName && ThirdName == that.ThirdName;
		}
		public override int GetHashCode() {
			return (FirstName?.GetHashCode() ?? 0 * 397) ^ (SecondName?.GetHashCode() ?? 0) * 397 ^ (ThirdName?.GetHashCode() ?? 0);
		}
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