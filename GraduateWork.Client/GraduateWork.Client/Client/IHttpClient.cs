using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public interface IHttpClient {
		bool Ping();

		GroupProxy[] GetAllGroups();
		DisciplineProxy[] GetAllDisciplines();
		StudentProxy[] GetAllStudents();

		bool AddGroup(GroupProxy group);
		bool EditGroup(GroupProxy oldGroup, GroupProxy newGroup);
		bool DeleteGroup(GroupProxy group);
	}
}