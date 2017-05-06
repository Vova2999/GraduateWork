using System;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Editors {
	public class DatabaseUserEditor : BaseHttpClient, IDatabaseUserEditor {
		public DatabaseUserEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(UserExtendedProxy extendedProxy) {
			SendRequest("AddUser", GetDefaultParameters(), extendedProxy.ToJson());
		}
		public void Edit(UserExtendedProxy oldExtendedProxy, UserExtendedProxy newExtendedProxy) {
			SendRequest("EditUser", GetDefaultParameters(), Tuple.Create(oldExtendedProxy, newExtendedProxy).ToJson());
		}
		public void Delete(UserBasedProxy basedProxy) {
			SendRequest("DeleteUser", GetDefaultParameters(), basedProxy.ToJson());
		}
	}
}