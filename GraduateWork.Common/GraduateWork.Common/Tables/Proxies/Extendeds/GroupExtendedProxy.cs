using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable UnusedMember.Global

	public class GroupExtendedProxy : GroupBasedProxy {
		[HeaderColumn("Студенты")]
		public StudentBasedProxy[] Students { get; set; }

		[HeaderColumn("Дисциплины")]
		public DisciplineBasedProxy[] Disciplines { get; set; }
	}
}