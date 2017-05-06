using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Readers {
	public class DatabaseGroupReader : BaseHttpClient, IDatabaseGroupReader {
		public DatabaseGroupReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public GroupBasedProxy[] GetAllBasedProies() {
			return SendRequest<GroupBasedProxy[]>("GetAllGroups", GetDefaultParameters());
		}
		public GroupExtendedProxy GetExtendedProxy(GroupBasedProxy basedProxy) {
			return SendRequest<GroupExtendedProxy>("GetExtendedGroup", GetDefaultParameters(), basedProxy.ToJson());
		}
		public GroupBasedProxy[] GetGroupsWithUsingFilters(string groupName, int? specialtyNumber, string specialtyName, string facultyName) {
			var parameters = GetDefaultParameters();
			AddParameterInNotNull(parameters, HttpParameters.GroupName, groupName);
			AddParameterInNotNull(parameters, HttpParameters.SpecialtyNumber, specialtyNumber?.ToString());
			AddParameterInNotNull(parameters, HttpParameters.SpecialtyName, specialtyName);
			AddParameterInNotNull(parameters, HttpParameters.FacultyName, facultyName);

			return SendRequest<GroupBasedProxy[]>("GetGroupsWithUsingFilters", parameters);
		}
	}
}