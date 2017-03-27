using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Server.Common.Database {
	public interface IDatabaseEditor {
		void AddGroup(GroupProxy groupProxy);
		void EditGroup(GroupProxy oldGroupProxy, GroupProxy newGroupProxy);
		void DeleteGroup(GroupProxy groupProxy);

		void AddStudent(StudentProxy studentProxy);
		void EditStudent(StudentProxy oldGroupProxy, StudentProxy newGroupProxy);
		void DeleteStudent(StudentProxy studentProxy);

		void AddDiscipline(DisciplineProxy disciplineProxy);
		void EditDiscipline(DisciplineProxy oldDisciplineProxy, DisciplineProxy newDisciplineProxy);
		void DeleteDiscipline(DisciplineProxy disciplineProxy);

		void AddUser(UserProxy userProxy);
		void EditUser(UserProxy oldUserProxy, UserProxy newUserProxy);
		void DeleteUser(UserProxy userProxy);
	}
}