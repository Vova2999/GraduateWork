using GraduateWork.Common.Tables.Proxies.Extendeds;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	// ReSharper disable UnusedMember.Global

	public class DiplomaSupplementCreator : ReportCreator {
		public override string TemplateName => "����������.docx";

		protected override Content CreateContent(StudentExtendedProxy student) {
			var content = new Content(
				new FieldContent("FirstName", student.FirstName),
				new FieldContent("SecondName", student.SecondName),
				new FieldContent("ThirdName", student.ThirdName),
				CreateDisciplinesTableContent(student));

			return content;
		}
		private TableContent CreateDisciplinesTableContent(StudentExtendedProxy student) {
			var tableContent = new TableContent("Disciplines");
			foreach (var assessmentByDiscipline in student.AssessmentByDisciplines)
				tableContent.AddRow(
					new FieldContent("NameOfDiscipline", assessmentByDiscipline.NameOfDiscipline),
					new FieldContent("Assessment", assessmentByDiscipline.Assessment.ToString()));

			return tableContent;
		}
	}
}