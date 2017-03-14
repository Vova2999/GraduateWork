using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public interface IHttpClient {
		bool Ping();
		GroupProxy[] GetAllGroups();
		DisciplineProxy[] GetAllDisciplines();
		StudentProxy[] GetAllStudents();
	}
}