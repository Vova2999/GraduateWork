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
		public DateTime YearOfReceipt { get; set; }

		[HeaderColumn("���� ����������")]
		public DateTime? YearOfDeduction { get; set; }

		[HeaderColumn("������")]
		public string NameOfGroup { get; set; }

		[HeaderColumn("����������")]
		public string[] NameOfDisciplines { get; set; }
	}
}