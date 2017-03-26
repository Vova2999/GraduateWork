using System.IO;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies;
using TemplateEngine.Docx;

namespace GraduateWork.Server.Reports.Creators {
	public abstract class ReportCreator {
		private const string folderWithTemplates = "Templates";
		private const string tempDocumentName = "tempDocument.docx";
		public abstract string TemplateName { get; }

		public FileWithContent Execute(StudentProxy student) {
			var fullTemplateName = Path.Combine(folderWithTemplates, TemplateName);
			File.Copy(fullTemplateName, tempDocumentName, true);

			using (var outputDocument = new TemplateProcessor(tempDocumentName).SetRemoveContentControls(true)) {
				outputDocument.FillContent(CreateContent(student));
				outputDocument.SaveChanges();
			}

			var fileWithContent = new FileWithContent(TemplateName, File.ReadAllBytes(tempDocumentName));
			File.Delete(tempDocumentName);
			return fileWithContent;
		}
		protected abstract Content CreateContent(StudentProxy student);
	}
}