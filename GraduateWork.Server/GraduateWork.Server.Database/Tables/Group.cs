using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateWork.Server.Database.Tables {
	// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
	// ReSharper disable UnusedAutoPropertyAccessor.Global

	public class Group {
		[Key]
		public int GroupId { get; set; }

		[Required, MaxLength(25), Index("IX_GroupUniques", 1, IsUnique = true)]
		public string GroupName { get; set; }

		[Required]
		public int SpecialtyNumber { get; set; }

		[Required, MaxLength(25)]
		public string SpecialtyName { get; set; }

		[Required, MaxLength(25)]
		public string FacultyName { get; set; }

		public virtual List<Student> Students { get; set; }

		public virtual List<Discipline> Disciplines { get; set; }
	}
}