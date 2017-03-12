using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateWork.Server.DataAccessLayer.Tables {
	public class Student {
		[Key]
		public int StudentId { get; set; }

		[Required]
		[MaxLength(25)]
		[Index("IX_Names", 1, IsUnique = true)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(25)]
		[Index("IX_Names", 2, IsUnique = true)]
		public string SecondName { get; set; }

		[Required]
		[MaxLength(25)]
		[Index("IX_Names", 3, IsUnique = true)]
		public string ThirdName { get; set; }

		public DateTime YearOfReceipt { get; set; }

		public DateTime? YearOfDeduction { get; set; }

		[Required]
		public virtual Group Group { get; set; }

		public virtual List<Discipline> Disciplines { get; set; }
	}
}