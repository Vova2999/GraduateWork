using System;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Clients.Database.Readers {
	public class DatabaseStudentReader : BaseHttpClient, IDatabaseStudentReader {
		public DatabaseStudentReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public StudentBasedProxy[] GetAllBasedProies() {
			return SendRequest<StudentBasedProxy[]>("GetAllStudents", GetDefaultParameters());
		}
		public StudentExtendedProxy GetExtendedProxy(StudentBasedProxy basedProxy) {
			return SendRequest<StudentExtendedProxy>("GetExtendedStudent", GetDefaultParameters(), basedProxy.ToJson());
		}
		public StudentBasedProxy[] GetStudentsWithUsingFilters(string firstName, string secondName, string thirdName, DateTime? dateOfBirth) {
			var parameters = GetDefaultParameters();
			AddParameterInNotNull(parameters, HttpParameters.FirstName, firstName);
			AddParameterInNotNull(parameters, HttpParameters.SecondName, secondName);
			AddParameterInNotNull(parameters, HttpParameters.ThirdName, thirdName);
			AddParameterInNotNull(parameters, HttpParameters.DateOfBirth, dateOfBirth?.ToString());

			return SendRequest<StudentBasedProxy[]>("GetStudentsWithUsingFilters", parameters);
		}
	}
}