using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Readers {
	public class DatabaseAssessmentByDisciplinesReader : BaseHttpClient, IDatabaseAssessmentByDisciplinesReader {
		public DatabaseAssessmentByDisciplinesReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public AssessmentByDiscipline[] GetAssessmentByDisciplinesFromGroupName(string groupName) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.GroupName] = groupName;

			return SendRequest<AssessmentByDiscipline[]>("GetAssessmentByDisciplinesFromGroupName", parameters);
		}
	}
}