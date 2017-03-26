using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	// ReSharper disable UnusedMember.Global

	public class GroupProxy {
		[HeaderColumn("Название группы")]
		public string NameOfGroup { get; set; }

		public override bool Equals(object obj) {
			var that = obj as GroupProxy;
			return that != null && NameOfGroup == that.NameOfGroup;
		}
		public override int GetHashCode() {
			return NameOfGroup?.GetHashCode() ?? 0;
		}
	}
}