using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Client {
	public interface IHttpClient {
		string Login { get; set; }
		string Password { get; set; }
		string ServerAddress { get; set; }

		void Ping();
		void CheckUserIsExist(string login, string password);

		GroupBasedProxy[] GetAllGroups();
		DisciplineBasedProxy[] GetAllDisciplines();
		StudentBasedProxy[] GetAllStudents();
		UserProxy[] GetAllUsers();

		void AddGroup(GroupExtendedProxy group);
		void EditGroup(GroupExtendedProxy oldGroup, GroupExtendedProxy newGroup);
		void DeleteGroup(GroupExtendedProxy group);

		void AddDiscipline(DisciplineExtendedProxy discipline);
		void EditDiscipline(DisciplineExtendedProxy oldDiscipline, DisciplineExtendedProxy newDiscipline);
		void DeleteDiscipline(DisciplineExtendedProxy discipline);

		void AddStudent(StudentExtendedProxy student);
		void EditStudent(StudentExtendedProxy oldGroup, StudentExtendedProxy newGroup);
		void DeleteStudent(StudentExtendedProxy student);

		void AddUser(UserProxy user);
		void EditUser(UserProxy oldUser, UserProxy newUser);
		void DeleteUser(UserProxy user);
	}
}