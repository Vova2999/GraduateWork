using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateWork.Server.Database.Tables {
	// ReSharper disable UnusedMember.Global

	public class User {
		[Key]
		public int UserId { get; set; }

		[Required]
		[MaxLength(25)]
		[Index("IX_Names", 1, IsUnique = true)]
		public string Login { get; set; }

		[Required]
		[MaxLength(25)]
		[Index("IX_Names", 2, IsUnique = true)]
		public string Password { get; set; }

		public int TypeAccess { get; set; }
	}

	public enum TypeAccess {
		None = 0x00,
		Read = 0x01,
		Edit = 0x02
	}
}