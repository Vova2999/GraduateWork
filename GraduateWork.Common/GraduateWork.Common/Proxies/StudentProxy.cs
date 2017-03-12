using System;

namespace GraduateWork.Common.Proxies {
	public class StudentProxy {
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string ThirdName { get; set; }
		public DateTime YearOfReceipt { get; set; }
		public DateTime? YearOfDeduction { get; set; }
		public string NameOfGroup { get; set; }
		public string[] NameOfDisciplines { get; set; }
	}
}