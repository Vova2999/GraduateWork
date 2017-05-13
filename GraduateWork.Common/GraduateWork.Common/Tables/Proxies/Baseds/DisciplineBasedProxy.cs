using System;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Enums;

namespace GraduateWork.Common.Tables.Proxies.Baseds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode

	public class DisciplineBasedProxy {
		[HeaderColumn("Название дисциплины")]
		public string DisciplineName { get; set; }

		[HeaderColumn("Тип дисциплины")]
		public ControlType ControlType { get; set; }

		[HeaderColumn("Название группы")]
		public string GroupName { get; set; }

		public override bool Equals(object obj) {
			var that = obj as DisciplineBasedProxy;
			return that != null &&
				string.Equals(DisciplineName, that.DisciplineName, StringComparison.InvariantCultureIgnoreCase) &&
				ControlType == that.ControlType &&
				string.Equals(GroupName, that.GroupName, StringComparison.InvariantCultureIgnoreCase);
		}
		public override int GetHashCode() {
			return (DisciplineName?.GetHashCode() ?? 0 * 397) ^ ((int)ControlType * 397) ^ (GroupName?.GetHashCode() ?? 0);
		}

		public DisciplineBasedProxy GetBasedClone() {
			return GetClone<DisciplineBasedProxy>();
		}
		protected TProxy GetClone<TProxy>() where TProxy : DisciplineBasedProxy, new() {
			return new TProxy {
				DisciplineName = DisciplineName,
				ControlType = ControlType,
				GroupName = GroupName
			};
		}
	}
}