using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Readers {
	public class DatabaseUserReader : BaseHttpClient, IDatabaseUserReader {
		public DatabaseUserReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public UserBasedProxy[] GetAllBasedProies() {
			return SendRequest<UserBasedProxy[]>("GetAllUsers", GetDefaultParameters());
		}
		public UserExtendedProxy GetExtendedProxy(UserBasedProxy basedProxy) {
			return SendRequest<UserExtendedProxy>("GetExtendedUser", GetDefaultParameters(), basedProxy.ToJson());
		}
		public UserBasedProxy[] GetUsersWithUsingFilters(string login) {
			var parameters = GetDefaultParameters();
			AddParameterInNotNull(parameters, HttpParameters.LoginForFilter, login);

			return SendRequest<UserBasedProxy[]>("GetUsersWithUsingFilters", parameters);
		}
	}
}