using System.Globalization;
using System.Linq;
using System.Reflection;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	// ReSharper disable ClassNeverInstantiated.Global

	public class AcademCreator : ReportCreator {
		public override string TemplateName => "Академ.docx";

		public AcademCreator(IDatabaseDisciplineReader databaseDisciplineReader,
							 IDatabaseGroupReader databaseGroupReader,
							 IDatabaseStudentReader databaseStudentReader)
			: base(databaseDisciplineReader, databaseGroupReader, databaseStudentReader) {
		}

		protected override Content CreateContent(StudentExtendedProxy student, DisciplineExtendedProxy[] disciplines, GroupExtendedProxy group) {
			return new Content(
				new FieldContent("FirstName", student.FirstName),
				new FieldContent("SecondName", student.SecondName),
				new FieldContent("ThirdName", student.ThirdName),
				new FieldContent("DateOfBirth", student.DateOfBirth.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU"))),
				new FieldContent("PreviousEducationName", student.PreviousEducationName),
				new FieldContent("PreviousEducationYear", student.PreviousEducationYear.ToString()),
				new FieldContent("EnrollmentYear", student.EnrollmentYear.ToString()),
				new FieldContent("EnrollmentName", student.EnrollmentName),
				new FieldContent("ExpulsionName", student.ExpulsionName),
				new FieldContent("ExpulsionYear", student.ExpulsionYear.ToString()),
				new FieldContent("ExpulsionOrderDate", student.ExpulsionOrderDate.ToString("dd.mm.yyyy")),
				new FieldContent("ExpulsionOrderNumber", student.ExpulsionOrderNumber.ToString()),
				new FieldContent("NormativePeriodOfStudy", (student.ExpulsionYear - student.EnrollmentYear).ToString()),
				new FieldContent("SpecialtyNumber", group.SpecialtyNumber.ToString()),
				new FieldContent("FacultyName", group.FacultyName),
				new FieldContent("SpecialtyName", group.SpecialtyName),
				CreateCourceWorksTable(student.AssessmentByDisciplines),
				CreateAssessmentByDisciplinesTable1(student.AssessmentByDisciplines, disciplines),
				CreateAssessmentByDisciplinesTable2(student.AssessmentByDisciplines, disciplines),
				CreateAssessmentByDisciplinesTable3(student.AssessmentByDisciplines),
				new FieldContent("SumTotalHours", disciplines.Sum(discipline => discipline.TotalHours).ToString()),
				new FieldContent("SumClassHours", disciplines.Sum(discipline => discipline.ClassHours).ToString())
			);
		}
		private TableContent CreateCourceWorksTable(AssessmentByDiscipline[] assessmentByDisciplines) {
			var tableContent = new TableContent("CourseWorks");
			foreach (var assessmentByDiscipline in assessmentByDisciplines.Where(ass => ass.ControlType == ControlType.CourseWork))
				tableContent.AddRow(
					new FieldContent("NameOfCourseWork", assessmentByDiscipline.NameOfDiscipline),
					new FieldContent("Assessment", typeof(Assessment).GetField(assessmentByDiscipline.Assessment.ToString()).GetCustomAttribute<NameEnumValueAttribute>().NameEnumValue.ToLower()));

			return tableContent;
		}
		private TableContent CreateAssessmentByDisciplinesTable1(AssessmentByDiscipline[] assessmentByDisciplines, DisciplineExtendedProxy[] disciplines) {
			var tableContent = new TableContent("AssessmentByDisciplines");
			foreach (var assessmentByDiscipline in assessmentByDisciplines.Where(ass => ass.ControlType == ControlType.Exam || ass.ControlType == ControlType.Credit || ass.ControlType == ControlType.DifferentiatedCredit))
				tableContent.AddRow(
					new FieldContent("NameOfDiscipline", assessmentByDiscipline.NameOfDiscipline),
					new FieldContent("ClassHours1", GetClassHours(assessmentByDiscipline, disciplines).ToString()),
					new FieldContent("Assessment1", typeof(Assessment).GetField(assessmentByDiscipline.Assessment.ToString()).GetCustomAttribute<NameEnumValueAttribute>().NameEnumValue.ToLower()));

			return tableContent;
		}
		private TableContent CreateAssessmentByDisciplinesTable2(AssessmentByDiscipline[] assessmentByDisciplines, DisciplineExtendedProxy[] disciplines) {
			var tableContent = new TableContent("AssessmentByDisciplines");
			foreach (var assessmentByDiscipline in assessmentByDisciplines.Where(ass => ass.ControlType == ControlType.Practice))
				tableContent.AddRow(
					new FieldContent("NameOfPractice", assessmentByDiscipline.NameOfDiscipline),
					new FieldContent("ClassHours2", GetClassHours(assessmentByDiscipline, disciplines).ToString()),
					new FieldContent("Assessment2", typeof(Assessment).GetField(assessmentByDiscipline.Assessment.ToString()).GetCustomAttribute<NameEnumValueAttribute>().NameEnumValue.ToLower()));

			return tableContent;
		}
		private TableContent CreateAssessmentByDisciplinesTable3(AssessmentByDiscipline[] assessmentByDisciplines) {
			var tableContent = new TableContent("AssessmentByDisciplines");
			foreach (var assessmentByDiscipline in assessmentByDisciplines.Where(ass => ass.ControlType == ControlType.StateExam))
				tableContent.AddRow(
					new FieldContent("NameOfStateExam", assessmentByDiscipline.NameOfDiscipline),
					new FieldContent("Assessment3", typeof(Assessment).GetField(assessmentByDiscipline.Assessment.ToString()).GetCustomAttribute<NameEnumValueAttribute>().NameEnumValue.ToLower()));

			return tableContent;
		}
		private int GetClassHours(AssessmentByDiscipline assessmentByDiscipline, DisciplineExtendedProxy[] disciplines) {
			return disciplines.First(discipline =>
				discipline.DisciplineName == assessmentByDiscipline.NameOfDiscipline &&
				discipline.ControlType == assessmentByDiscipline.ControlType).ClassHours;
		}
	}
}