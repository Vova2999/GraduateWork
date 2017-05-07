using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DiplomaSupplementCreator : ReportCreator {
		public override string TemplateName => "����������.docx";

		public DiplomaSupplementCreator(IDatabaseDisciplineReader databaseDisciplineReader,
										IDatabaseGroupReader databaseGroupReader,
										IDatabaseStudentReader databaseStudentReader)
			: base(databaseDisciplineReader, databaseGroupReader, databaseStudentReader) {
		}

		protected override Content CreateContent(StudentExtendedProxy student, DisciplineExtendedProxy[] disciplines, GroupExtendedProxy group) {
			var content = new Content(
				new FieldContent("FirstName", student.FirstName),
				new FieldContent("SecondName", student.SecondName),
				new FieldContent("ThirdName", student.ThirdName),
				CreateDisciplinesTableContent(student)
			);

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