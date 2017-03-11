using System.ComponentModel.DataAnnotations;

namespace GraduateWork.Server.DataAccessLayer.Tables {
	public class Group {
		[Key]
		public int GroupId { get; set; }

		[Required]
		public string NameOfGroup { get; set; }
	}
}