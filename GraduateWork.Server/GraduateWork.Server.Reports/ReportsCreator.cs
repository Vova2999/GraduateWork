using System.Linq;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common;
using GraduateWork.Server.Reports.Creators;

namespace GraduateWork.Server.Reports {
	public class ReportsCreator : IReportsCreator {
		private readonly ReportCreator[] reportCreators;

		public ReportsCreator(ReportCreator[] reportCreators) {
			this.reportCreators = reportCreators;
		}

		public FileWithContent CreateAcadem(StudentProxy student) {
			return reportCreators.FirstOrDefault(creator => creator.TemplateName == "Академ.docx")?.Execute(student);
		}
		public FileWithContent CreateDiploma(StudentProxy student) {
			return reportCreators.FirstOrDefault(creator => creator.TemplateName == "Диплом.docx")?.Execute(student);
		}
		public FileWithContent CreateDiplomaSupplement(StudentProxy student) {
			return reportCreators.FirstOrDefault(creator => creator.TemplateName == "Приложение.docx")?.Execute(student);
		}
	}
}