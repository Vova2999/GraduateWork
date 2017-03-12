using System.Collections.Generic;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public interface IHttpClient {
		bool Ping();
		IEnumerable<GroupProxy> GetAllGroups();
		IEnumerable<DisciplineProxy> GetAllDisciplines();
		IEnumerable<StudentProxy> GetAllStudents();
	}
}