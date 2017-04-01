using System.Collections.Concurrent;
using System.Linq;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Common.Reports;
using GraduateWork.Server.Reports.Creators;

namespace GraduateWork.Server.Reports {
	// ReSharper disable ClassNeverInstantiated.Global

	public class ReportsCreator : IReportsCreator {
		private readonly ReportCreator[] reportCreators;
		private readonly ConcurrentDictionary<string, ReportCreator> hashedCreators;

		public ReportsCreator(ReportCreator[] reportCreators) {
			this.reportCreators = reportCreators;
			hashedCreators = new ConcurrentDictionary<string, ReportCreator>();
		}

		public FileWithContent CreateAcadem(StudentExtendedProxy student) {
			return hashedCreators.GetOrAdd("Академ.docx", GetReportCreator).Execute(student);
		}
		public FileWithContent CreateDiploma(StudentExtendedProxy student) {
			return hashedCreators.GetOrAdd("Диплом.docx", GetReportCreator).Execute(student);
		}
		public FileWithContent CreateDiplomaSupplement(StudentExtendedProxy student) {
			return hashedCreators.GetOrAdd("Приложение.docx", GetReportCreator).Execute(student);
		}
		private ReportCreator GetReportCreator(string templateName) {
			return reportCreators.First(creator => creator.TemplateName == templateName);
		}
	}
}