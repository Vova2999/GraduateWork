﻿using System.Linq;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedMember.Global

	public class GroupExtendedProxy : GroupBasedProxy {
		[HeaderColumn("Студенты")]
		public StudentBasedProxy[] Students { get; set; }

		[HeaderColumn("Дисциплины")]
		public DisciplineBasedProxy[] Disciplines { get; set; }

		public GroupExtendedProxy GetExtendedClone() {
			var clone = GetClone<GroupExtendedProxy>();
			clone.Students = Students.Select(student => student.GetBasedClone()).ToArray();
			clone.Disciplines = Disciplines.Select(discipline => discipline.GetBasedClone()).ToArray();

			return clone;
		}
	}
}