using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies.Baseds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedAutoPropertyAccessor.Global

	public class DisciplineBasedProxy {
		[HeaderColumn("Название дисциплины")]
		public string DisciplineName { get; set; }

		[HeaderColumn("Группа")]
		public GroupBasedProxy Group { get; set; }

		public override bool Equals(object obj) {
			var that = obj as DisciplineBasedProxy;
			return that != null &&
				string.Equals(DisciplineName, that.DisciplineName, StringComparison.InvariantCultureIgnoreCase) &&
				Equals(Group, that.Group);
		}
		public override int GetHashCode() {
			return ((DisciplineName?.GetHashCode() ?? 0) * 397) ^ (Group?.GetHashCode() ?? 0);
		}

		public DisciplineBasedProxy GetBasedClone() {
			return GetClone<DisciplineBasedProxy>();
		}
		protected TProxy GetClone<TProxy>() where TProxy : DisciplineBasedProxy, new() {
			return new TProxy {
				DisciplineName = DisciplineName,
				Group = Group.GetBasedClone()
			};
		}
	}
}