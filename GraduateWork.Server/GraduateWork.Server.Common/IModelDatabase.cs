using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Server.Common {
	public interface IModelDatabase {
		GroupProxy[] GetAllGroups();
		void AddGroup(GroupProxy groupProxy);
		void EditGroup(GroupProxy oldGroupProxy, GroupProxy newGroupProxy);
		void DeleteGroup(GroupProxy groupProxy);

		DisciplineProxy[] GetAllDisciplines();
		void AddDiscipline(DisciplineProxy disciplineProxy);
		void EditDiscipline(DisciplineProxy oldDisciplineProxy, DisciplineProxy newDisciplineProxy);
		void DeleteDiscipline(DisciplineProxy disciplineProxy);

		StudentProxy[] GetAllStudents();
		void AddStudent(StudentProxy studentProxy);
		void EditStudent(StudentProxy oldGroupProxy, StudentProxy newGroupProxy);
		void DeleteStudent(StudentProxy studentProxy);
	}
}