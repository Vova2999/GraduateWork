using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies {
	public class DisciplineProxy {
		[HeaderColumn("Название дисциплины")]
		public string NameOfDiscipline { get; set; }

		public override bool Equals(object obj) {
			var that = obj as DisciplineProxy;
			return that != null && NameOfDiscipline == that.NameOfDiscipline;
		}
		public override int GetHashCode() {
			return NameOfDiscipline?.GetHashCode() ?? 0;
		}
	}
}