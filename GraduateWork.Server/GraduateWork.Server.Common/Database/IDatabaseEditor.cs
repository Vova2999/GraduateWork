using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Server.Common.Database {
	public interface IDatabaseEditor {
		void AddDiscipline(DisciplineExtendedProxy discipline);
		void EditDiscipline(DisciplineExtendedProxy oldDiscipline, DisciplineExtendedProxy newDiscipline);
		void DeleteDiscipline(DisciplineBasedProxy discipline);

		void AddGroup(GroupExtendedProxy group);
		void EditGroup(GroupExtendedProxy oldGroup, GroupExtendedProxy newGroup);
		void DeleteGroup(GroupBasedProxy group);

		void AddStudent(StudentExtendedProxy student);
		void EditStudent(StudentExtendedProxy oldStudent, StudentExtendedProxy newStudent);
		void DeleteStudent(StudentBasedProxy student);

		void AddUser(UserExtendedProxy user);
		void EditUser(UserExtendedProxy oldUser, UserExtendedProxy newUser);
		void DeleteUser(UserBasedProxy user);
	}
}