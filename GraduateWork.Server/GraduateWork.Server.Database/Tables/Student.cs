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

		[Required, MaxLength(25), Index("IX_StudentUniques", 1, IsUnique = true)]
		public string FirstName { get; set; }

		[Required, MaxLength(25), Index("IX_StudentUniques", 2, IsUnique = true)]
		public string SecondName { get; set; }

		[Required, MaxLength(25), Index("IX_StudentUniques", 3, IsUnique = true)]
		public string ThirdName { get; set; }

		[Required, Index("IX_StudentUniques", 4, IsUnique = true)]
		public DateTime DateOfBirth { get; set; }

		[Required, MaxLength(100)]
		public string PreviousEducationName { get; set; }

		[Required]
		public int PreviousEducationYear { get; set; }

		[Required, MaxLength(100)]
		public string EnrollmentName { get; set; }

		[Required]
		public int EnrollmentYear { get; set; }

		[Required, MaxLength(100)]
		public string DeductionName { get; set; }

		[Required]
		public int DeductionYear { get; set; }

		[Required, MaxLength(100)]
		public string DiplomaTopic { get; set; }

		[Required, Range(3, 5)]
		public int DiplomaAssessment { get; set; }

		[Required]
		public DateTime ProtectionDate { get; set; }

		[Required, MaxLength(20)]
		public string ProtocolNumber { get; set; }

		[Required, MaxLength(20)]
		public string RegistrationNumber { get; set; }

		[Required]
		public DateTime RegistrationDate { get; set; }

		[Required]
		public virtual Group Group { get; set; }

		public virtual List<AssessmentByDiscipline> AssessmentByDisciplines { get; set; }
	}
}