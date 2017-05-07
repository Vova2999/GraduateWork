using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies.Baseds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable MemberCanBeProtected.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedMember.Global

	public class GroupBasedProxy {
		[HeaderColumn("Название группы")]
		public string GroupName { get; set; }

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
				GroupName = GroupName
			};
		}
	}
}