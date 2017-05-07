using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DiplomaCreator : ReportCreator {
		public override string TemplateName => "Диплом.docx";

		public DiplomaCreator(IDatabaseDisciplineReader databaseDisciplineReader,
							  IDatabaseGroupReader databaseGroupReader,
							  IDatabaseStudentReader databaseStudentReader)
			: base(databaseDisciplineReader, databaseGroupReader, databaseStudentReader) {
		}

		protected override Content CreateContent(StudentExtendedProxy student, DisciplineExtendedProxy[] disciplines, GroupExtendedProxy group) {
			return new Content(
				new FieldContent("FirstName", student.FirstName),
				new FieldContent("SecondName", student.SecondName),
				new FieldContent("ThirdName", student.ThirdName));
		}
	}
}