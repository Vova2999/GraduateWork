using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Server.Common.Database {
	public interface IDatabaseEditor {
		void AddDiscipline(DisciplineExtendedProxy discipline);
		void EditDiscipline(DisciplineExtendedProxy oldDiscipline, DisciplineExtendedProxy newDiscipline);
		void DeleteDiscipline(DisciplineExtendedProxy discipline);

		void AddGroup(GroupExtendedProxy group);
		void EditGroup(GroupExtendedProxy oldGroup, GroupExtendedProxy newGroup);
		void DeleteGroup(GroupExtendedProxy group);

		void AddStudent(StudentExtendedProxy student);
		void EditStudent(StudentExtendedProxy oldStudent, StudentExtendedProxy newStudent);
		void DeleteStudent(StudentExtendedProxy student);

		void AddUser(UserExtendedProxy user);
		void EditUser(UserExtendedProxy oldUser, UserExtendedProxy newUser);
		void DeleteUser(UserExtendedProxy user);
	}
}