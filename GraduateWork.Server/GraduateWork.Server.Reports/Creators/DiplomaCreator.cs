using GraduateWork.Common.Tables.Proxies.Extendeds;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	// ReSharper disable UnusedMember.Global

	public class DiplomaCreator : ReportCreator {
		public override string TemplateName => "Диплом.docx";

		protected override Content CreateContent(StudentExtendedProxy student) {
			return new Content(
				new FieldContent("FirstName", student.FirstName),
				new FieldContent("SecondName", student.SecondName),
				new FieldContent("ThirdName", student.ThirdName));
		}
	}
}