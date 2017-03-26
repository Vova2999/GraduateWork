using GraduateWork.Common.Tables.Proxies;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	public class AcademCreator : ReportCreator {
		public override string TemplateName => "������.docx";

		protected override Content CreateContent(StudentProxy student) {
			return new Content(
				new FieldContent("FirstName", student.FirstName),
				new FieldContent("SecondName", student.SecondName),
				new FieldContent("ThirdName", student.ThirdName));
		}
	}
}