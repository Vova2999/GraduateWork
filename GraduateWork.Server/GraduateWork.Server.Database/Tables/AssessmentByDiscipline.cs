using System.ComponentModel.DataAnnotations;

namespace GraduateWork.Server.Database.Tables {
	public class AssessmentByDiscipline {
		[Key]
		public int AssessmentByDisciplineId { get; set; }

		[Required]
		public int StudentId { get; set; }

		public virtual Student Student { get; set; }

		[Required]
		public int DisciplineId { get; set; }

		public virtual Discipline Discipline { get; set; }

		public Assessment Assessment { get; set; }
	}

	public enum Assessment {
		Excellent = 5,
		Good = 4,
		Satisfactory = 3
	}
}