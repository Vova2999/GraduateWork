using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Server.Common {
	public interface IModelDatabase {
		GroupProxy[] GetAllGroups();
		DisciplineProxy[] GetAllDisciplines();
		StudentProxy[] GetAllStudents();

		void AddGroup(GroupProxy groupProxy);
		void EditGroup(GroupProxy oldGroupProxy, GroupProxy newGroupProxy);
		void DeleteGroup(GroupProxy groupProxy);

		void AddDiscipline(DisciplineProxy disciplineProxy);
		void EditDiscipline(DisciplineProxy oldDisciplineProxy, DisciplineProxy newDisciplineProxy);
		void DeleteDiscipline(DisciplineProxy disciplineProxy);

		void AddStudent(StudentProxy studentProxy);
		void EditStudent(StudentProxy oldGroupProxy, StudentProxy newGroupProxy);
		void DeleteStudent(StudentProxy studentProxy);

		StudentProxy[] GetAllStudentsFormGroupByName(string nameOfGroup);
	}
}