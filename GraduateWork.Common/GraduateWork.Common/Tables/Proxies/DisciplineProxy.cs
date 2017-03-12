using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies {
	public class DisciplineProxy {
		[HeaderColumn("Название дисциплины")]
		public string NameOfDiscipline { get; set; }
	}
}