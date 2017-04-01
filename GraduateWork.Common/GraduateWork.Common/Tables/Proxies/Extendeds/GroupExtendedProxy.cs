using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable UnusedMember.Global

	public class GroupExtendedProxy : GroupBasedProxy {
		[HeaderColumn("Название специальности")]
		public string SpecialtyName { get; set; }

		[HeaderColumn("Номер специальности")]
		public int SpecialtyNumber { get; set; }

		[HeaderColumn("Название факультета")]
		public string FacultyName { get; set; }

		[HeaderColumn("Студенты")]
		public StudentBasedProxy[] Students { get; set; }

		[HeaderColumn("Дисциплины")]
		public DisciplineBasedProxy[] Disciplines { get; set; }
	}
}