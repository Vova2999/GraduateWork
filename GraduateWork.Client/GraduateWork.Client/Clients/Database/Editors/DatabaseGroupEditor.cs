using System;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Editors {
	public class DatabaseGroupEditor : BaseHttpClient, IDatabaseGroupEditor {
		public DatabaseGroupEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(GroupExtendedProxy extendedProxy) {
			SendRequest("AddGroup", GetDefaultParameters(), extendedProxy.ToJson());
		}
		public void Edit(GroupExtendedProxy oldExtendedProxy, GroupExtendedProxy newExtendedProxy) {
			SendRequest("EditGroup", GetDefaultParameters(), Tuple.Create(oldExtendedProxy, newExtendedProxy).ToJson());
		}
		public void Delete(GroupBasedProxy basedProxy) {
			SendRequest("DeleteGroup", GetDefaultParameters(), basedProxy.ToJson());
		}
	}
}