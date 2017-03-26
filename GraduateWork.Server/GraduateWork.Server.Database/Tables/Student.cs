using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateWork.Server.Database.Tables {
	// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
	// ReSharper disable UnusedMember.Global

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

		public DateTime DateOfReceipt { get; set; }

		public DateTime? DateOfDeduction { get; set; }

		[Required]
		public virtual Group Group { get; set; }

		public virtual List<AssessmentByDiscipline> AssessmentByDisciplines { get; set; }
	}
}