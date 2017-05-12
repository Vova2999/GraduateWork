using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Readers {
	public class DatabaseDisciplineReader : BaseHttpClient, IDatabaseDisciplineReader {
		public DatabaseDisciplineReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public DisciplineBasedProxy[] GetAllBasedProies() {
			return SendRequest<DisciplineBasedProxy[]>("GetAllDisciplines", GetDefaultParameters());
		}
		public DisciplineExtendedProxy GetExtendedProxy(DisciplineBasedProxy basedProxy) {
			return SendRequest<DisciplineExtendedProxy>("GetExtendedDiscipline", GetDefaultParameters(), basedProxy.ToJson());
		}
		public DisciplineBasedProxy[] GetDisciplinesWithUsingFilters(string disciplineName, ControlType? controlType, string groupName) {
			var parameters = GetDefaultParameters();
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.DisciplineName, disciplineName);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.ControlType, controlType?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.GroupName, groupName);

			return SendRequest<DisciplineBasedProxy[]>("GetDisciplinesWithUsingFilters", parameters);
		}
	}
}