using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies.Baseds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	// ReSharper disable UnusedMember.Global

	public class GroupBasedProxy {
		[HeaderColumn("Название группы")]
		public string GroupName { get; set; }

		[HeaderColumn("Название специальности")]
		public string SpecialtyName { get; set; }

		[HeaderColumn("Номер специальности")]
		public int SpecialtyNumber { get; set; }

		[HeaderColumn("Название факультета")]
		public string FacultyName { get; set; }

		public override bool Equals(object obj) {
			var that = obj as GroupBasedProxy;
			return that != null &&
				string.Equals(GroupName, that.GroupName, StringComparison.InvariantCultureIgnoreCase);
		}
		public override int GetHashCode() {
			return GroupName?.GetHashCode() ?? 0;
		}
	}
}