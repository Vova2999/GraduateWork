using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduateWork.Server.DataAccessLayer.Tables {
	public class Discipline {
		[Key]
		public int DisciplineId { get; set; }

		[Required]
		public string NameOfDiscipline { get; set; }

		public virtual List<Student> Students { get; set; }
	}
}