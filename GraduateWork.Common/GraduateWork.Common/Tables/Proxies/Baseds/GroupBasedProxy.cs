using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies.Baseds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable MemberCanBeProtected.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode

	public class GroupBasedProxy {
		[HeaderColumn("Название группы")]
		public string GroupName { get; set; }

		[HeaderColumn("Номер специальности")]
		public int SpecialtyNumber { get; set; }

		[HeaderColumn("Название специальности")]
		public string SpecialtyName { get; set; }

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

		public GroupBasedProxy GetBasedClone() {
			return GetClone<GroupBasedProxy>();
		}
		public TProxy GetClone<TProxy>() where TProxy : GroupBasedProxy, new() {
			return new TProxy {
				GroupName = GroupName,
				SpecialtyNumber = SpecialtyNumber,
				SpecialtyName = SpecialtyName,
				FacultyName = FacultyName
			};
		}
	}
}