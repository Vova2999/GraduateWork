using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateWork.Server.DataAccessLayer.Tables {
	public class Discipline {
		[Key]
		public int DisciplineId { get; set; }

		[Required]
		[MaxLength(25)]
		[Index(IsUnique = true)]
		public string NameOfDiscipline { get; set; }

		public virtual List<AssessmentByDiscipline> AssessmentByDisciplines { get; set; }
	}
}