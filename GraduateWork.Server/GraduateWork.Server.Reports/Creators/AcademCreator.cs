using GraduateWork.Common.Tables.Proxies;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	// ReSharper disable UnusedMember.Global

	public class AcademCreator : ReportCreator {
		public override string TemplateName => "Академ.docx";

		protected override Content CreateContent(StudentProxy student) {
			return new Content(
				new FieldContent("FirstName", student.FirstName),
				new FieldContent("SecondName", student.SecondName),
				new FieldContent("ThirdName", student.ThirdName));
		}
	}
}