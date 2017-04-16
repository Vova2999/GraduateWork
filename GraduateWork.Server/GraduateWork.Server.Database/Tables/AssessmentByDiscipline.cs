using System.ComponentModel.DataAnnotations;

namespace GraduateWork.Server.Database.Tables {
	// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	// ReSharper disable UnusedMember.Global

	public class AssessmentByDiscipline {
		[Key]
		public int AssessmentByDisciplineId { get; set; }

		[Required]
		public int StudentId { get; set; }

		[Required]
		public virtual Student Student { get; set; }

		[Required]
		public int DisciplineId { get; set; }

		[Required]
		public virtual Discipline Discipline { get; set; }

		[Required]
		public int GroupId { get; set; }

		[Required]
		public virtual Group Group { get; set; }

		public int Assessment { get; set; }
	}
}