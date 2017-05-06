using GraduateWork.Common.Extensions;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Reports {
	public class ReportsCreator : BaseHttpClient, IReportsCreator {
		public ReportsCreator(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public FileWithContent CreateAcadem(StudentExtendedProxy student) {
			return SendRequest<FileWithContent>("CreateAcademReport", GetDefaultParameters(), student.ToJson());
		}
		public FileWithContent CreateDiploma(StudentExtendedProxy student) {
			return SendRequest<FileWithContent>("CreateDiplomaReport", GetDefaultParameters(), student.ToJson());
		}
		public FileWithContent CreateDiplomaSupplement(StudentExtendedProxy student) {
			return SendRequest<FileWithContent>("CreateDiplomaSupplementReport", GetDefaultParameters(), student.ToJson());
		}
	}
}