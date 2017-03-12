using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateWork.Server.DataAccessLayer.Tables {
	public class Group {
		[Key]
		public int GroupId { get; set; }

		[Required]
		[MaxLength(15)]
		[Index(IsUnique = true)]
		public string NameOfGroup { get; set; }

		public virtual List<Student> Students { get; set; }
	}
}