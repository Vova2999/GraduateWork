using GraduateWork.Common.Extensions;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Client.Clients.Reports {
	public class ReportsCreator : BaseHttpClient, IReportsCreator {
		public ReportsCreator(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public FileWithContent CreateAcadem(StudentBasedProxy student) {
			return SendRequest<FileWithContent>("CreateAcademReport", GetDefaultParameters(), student.ToJson());
		}
		public FileWithContent CreateDiploma(StudentBasedProxy student) {
			return SendRequest<FileWithContent>("CreateDiplomaReport", GetDefaultParameters(), student.ToJson());
		}
		public FileWithContent CreateDiplomaSupplement(StudentBasedProxy student) {
			return SendRequest<FileWithContent>("CreateDiplomaSupplementReport", GetDefaultParameters(), student.ToJson());
		}
	}
}