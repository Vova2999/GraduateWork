using System;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Editors {
	public class DatabaseStudentEditor : BaseHttpClient, IDatabaseStudentEditor {
		public DatabaseStudentEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(StudentExtendedProxy extendedProxy) {
			SendRequest("AddStudent", GetDefaultParameters(), extendedProxy.ToJson());
		}
		public void Edit(StudentExtendedProxy oldExtendedProxy, StudentExtendedProxy newExtendedProxy) {
			SendRequest("EditStudent", GetDefaultParameters(), Tuple.Create(oldExtendedProxy, newExtendedProxy).ToJson());
		}
		public void Delete(StudentBasedProxy basedProxy) {
			SendRequest("DeleteStudent", GetDefaultParameters(), basedProxy.ToJson());
		}
	}
}