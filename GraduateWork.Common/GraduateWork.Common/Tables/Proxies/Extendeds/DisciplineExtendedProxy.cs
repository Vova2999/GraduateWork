using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable MemberCanBeProtected.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedMember.Global

	public class DisciplineExtendedProxy : DisciplineBasedProxy {
		[HeaderColumn("Тип дисциплины")]
		public ControlType ControlType { get; set; }

		[HeaderColumn("Всего часов")]
		public int TotalHours { get; set; }

		[HeaderColumn("Аудиторных часов")]
		public int ClassHours { get; set; }

		public DisciplineExtendedProxy GetExtendedClone() {
			var clone = GetClone<DisciplineExtendedProxy>();
			clone.ControlType = ControlType;
			clone.TotalHours = TotalHours;
			clone.ClassHours = ClassHours;

			return clone;
		}
	}
}