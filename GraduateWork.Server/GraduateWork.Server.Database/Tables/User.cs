using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateWork.Server.Database.Tables {
	// ReSharper disable UnusedMember.Global

	public class User {
		[Key]
		public int UserId { get; set; }

		[Required, MaxLength(25), Index("IX_UserUniques", 1, IsUnique = true)]
		public string Login { get; set; }

		[Required, MaxLength(25), Index("IX_UserUniques", 2, IsUnique = true)]
		public string Password { get; set; }

		public int AccessType { get; set; }
	}
}