﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GraduateWork.Common.Tables.Enums;

namespace GraduateWork.Server.Database.Tables {
	// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
	// ReSharper disable UnusedAutoPropertyAccessor.Global

	public class Discipline {
		[Key]
		public int DisciplineId { get; set; }

		[Required, MaxLength(64), Index("IX_DisciplineUniques", 1, IsUnique = true)]
		public string DisciplineName { get; set; }

		[Required]
		public ControlType ControlType { get; set; }

		[Required]
		public int TotalHours { get; set; }

		[Required]
		public int ClassHours { get; set; }

		[Required, Index("IX_DisciplineUniques", 2, IsUnique = true)]
		public int GroupId { get; set; }

		[Required]
		public virtual Group Group { get; set; }
	}
}