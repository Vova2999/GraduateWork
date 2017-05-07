using System.IO;
using System.Linq;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	public abstract class ReportCreator {
		public abstract string TemplateName { get; }
		private const string folderWithTemplates = "Templates";
		private const string tempDocumentName = "tempDocument.docx";
		private readonly IDatabaseDisciplineReader databaseDisciplineReader;
		private readonly IDatabaseGroupReader databaseGroupReader;
		private readonly IDatabaseStudentReader databaseStudentReader;

		protected ReportCreator(IDatabaseDisciplineReader databaseDisciplineReader,
								IDatabaseGroupReader databaseGroupReader,
								IDatabaseStudentReader databaseStudentReader) {
			this.databaseDisciplineReader = databaseDisciplineReader;
			this.databaseGroupReader = databaseGroupReader;
			this.databaseStudentReader = databaseStudentReader;
		}

		public FileWithContent Execute(StudentBasedProxy student) {
			var fullTemplateName = Path.Combine(folderWithTemplates, TemplateName);
			File.Copy(fullTemplateName, tempDocumentName, true);

			var studentExtended = databaseStudentReader.GetExtendedProxy(student);
			var disciplines = databaseDisciplineReader.GetDisciplinesWithUsingFilters(null, null, studentExtended.GroupName)
				.Select(databaseDisciplineReader.GetExtendedProxy).ToArray();
			var group = databaseGroupReader.GetGroupsWithUsingFilters(studentExtended.GroupName)
				.Select(databaseGroupReader.GetExtendedProxy).First();

			using (var outputDocument = new TemplateProcessor(tempDocumentName).SetRemoveContentControls(true)) {
				outputDocument.FillContent(CreateContent(studentExtended, disciplines, group));
				outputDocument.SaveChanges();
			}

			var fileWithContent = new FileWithContent(TemplateName, File.ReadAllBytes(tempDocumentName));
			File.Delete(tempDocumentName);
			return fileWithContent;
		}
		protected abstract Content CreateContent(StudentExtendedProxy student, DisciplineExtendedProxy[] disciplines, GroupExtendedProxy group);
	}
}