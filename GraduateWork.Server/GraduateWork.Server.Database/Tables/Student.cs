using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateWork.Server.Database.Tables {
	// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
	// ReSharper disable UnusedAutoPropertyAccessor.Global

	public class Student {
		[Key]
		public int StudentId { get; set; }

		[Required, MaxLength(64), Index("IX_StudentUniques", 1, IsUnique = true)]
		public string FirstName { get; set; }

		[Required, MaxLength(64), Index("IX_StudentUniques", 2, IsUnique = true)]
		public string SecondName { get; set; }

		[Required, MaxLength(64), Index("IX_StudentUniques", 3, IsUnique = true)]
		public string ThirdName { get; set; }

		[Required, Index("IX_StudentUniques", 4, IsUnique = true)]
		public DateTime DateOfBirth { get; set; }

		[Required, MaxLength(256)]
		public string PreviousEducationName { get; set; }

		[Required]
		public int PreviousEducationYear { get; set; }

		[Required, MaxLength(256)]
		public string EnrollmentName { get; set; }

		[Required]
		public int EnrollmentYear { get; set; }

		[Required, MaxLength(256)]
		public string ExpulsionName { get; set; }

		[Required]
		public int ExpulsionYear { get; set; }

		[Required]
		public DateTime ExpulsionOrderDate { get; set; }

		[Required]
		public int ExpulsionOrderNumber { get; set; }

		[Required, MaxLength(256)]
		public string DiplomaTopic { get; set; }

		[Required]
		public int DiplomaAssessment { get; set; }

		[Required]
		public DateTime ProtectionDate { get; set; }

		[Required, MaxLength(64)]
		public string ProtocolNumber { get; set; }

		[Required, MaxLength(64)]
		public string RegistrationNumber { get; set; }

		[Required]
		public DateTime RegistrationDate { get; set; }

		[Required]
		public int GroupId { get; set; }

		[Required]
		public virtual Group Group { get; set; }

		public virtual List<AssessmentByDiscipline> AssessmentByDisciplines { get; set; }
	}
}