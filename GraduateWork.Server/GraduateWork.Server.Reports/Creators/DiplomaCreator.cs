using System.Globalization;
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
			var registrationDate = student.RegistrationDate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU")).Split();

			return new Content(
				new FieldContent("RegistrationNumber", student.RegistrationNumber),
				new FieldContent("ProtectionDate", student.ProtectionDate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU"))),
				new FieldContent("RegistrationNumber", student.RegistrationNumber),
				new FieldContent("FirstName", student.FirstName),
				new FieldContent("SecondName", student.SecondName),
				new FieldContent("ThirdName", student.ThirdName),
				new FieldContent("SpecialtyNumber", group.SpecialtyNumber.ToString()),
				new FieldContent("FacultyName", group.FacultyName),
				new FieldContent("ProtocolNumber", student.ProtocolNumber),
				new FieldContent("RegistrationDateDay", registrationDate[0]),
				new FieldContent("RegistrationDateMonth", registrationDate[1]),
				new FieldContent("RegistrationDateYear", registrationDate[2]));
		}
	}
}