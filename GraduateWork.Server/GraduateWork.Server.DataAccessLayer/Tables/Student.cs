using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduateWork.Server.DataAccessLayer.Tables {
	public class Student {
		[Key]
		public int StudentId { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string SecondName { get; set; }

		[Required]
		public string ThirdName { get; set; }

		public DateTime YearOfReceipt { get; set; }

		public DateTime? YearOfDeduction { get; set; }

		[Required]
		public virtual Group Group { get; set; }

		public virtual List<Discipline> Disciplines { get; set; }
	}
}