using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public interface IHttpClient {
		void Ping();

		GroupProxy[] GetAllGroups();
		DisciplineProxy[] GetAllDisciplines();
		StudentProxy[] GetAllStudents();

		void AddGroup(GroupProxy group);
		void EditGroup(GroupProxy oldGroup, GroupProxy newGroup);
		void DeleteGroup(GroupProxy group);
	}
}