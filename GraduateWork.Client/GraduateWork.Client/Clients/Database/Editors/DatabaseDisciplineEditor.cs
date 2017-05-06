using System;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Editors {
	public class DatabaseDisciplineEditor : BaseHttpClient, IDatabaseDisciplineEditor {
		public DatabaseDisciplineEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(DisciplineExtendedProxy extendedProxy) {
			SendRequest("AddDiscipline", GetDefaultParameters(), extendedProxy.ToJson());
		}
		public void Edit(DisciplineExtendedProxy oldExtendedProxy, DisciplineExtendedProxy newExtendedProxy) {
			SendRequest("EditDiscipline", GetDefaultParameters(), Tuple.Create(oldExtendedProxy, newExtendedProxy).ToJson());
		}
		public void Delete(DisciplineBasedProxy basedProxy) {
			SendRequest("DeleteDiscipline", GetDefaultParameters(), basedProxy.ToJson());
		}
	}
}