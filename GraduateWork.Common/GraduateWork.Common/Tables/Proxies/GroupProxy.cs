using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies {
	public class GroupProxy {
		[HeaderColumn("Название группы")]
		public string NameOfGroup { get; set; }
	}
}