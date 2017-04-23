using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Client {
	// ReSharper disable UnusedMemberInSuper.Global

	public interface IHttpClient {
		string Login { get; set; }
		string Password { get; set; }
		string ServerAddress { get; set; }

		void Ping();
		void CheckUserIsExist(string login, string password);

		AssessmentByDiscipline[] GetAssessmentByDisciplinesFromGroupName(string groupName);

		DisciplineBasedProxy[] GetAllDisciplines();
		GroupBasedProxy[] GetAllGroups();
		StudentBasedProxy[] GetAllStudents();
		UserBasedProxy[] GetAllUsers();

		DisciplineExtendedProxy GetExtendedDiscipline(DisciplineBasedProxy discipline);
		GroupExtendedProxy GetExtendedGroup(GroupBasedProxy group);
		StudentExtendedProxy GetExtendedStudent(StudentBasedProxy student);
		UserExtendedProxy GetExtendedUser(UserBasedProxy user);

		void AddDiscipline(DisciplineExtendedProxy discipline);
		void EditDiscipline(DisciplineExtendedProxy oldDiscipline, DisciplineExtendedProxy newDiscipline);
		void DeleteDiscipline(DisciplineBasedProxy discipline);

		void AddGroup(GroupExtendedProxy group);
		void EditGroup(GroupExtendedProxy oldGroup, GroupExtendedProxy newGroup);
		void DeleteGroup(GroupBasedProxy group);

		void AddStudent(StudentExtendedProxy student);
		void EditStudent(StudentExtendedProxy oldGroup, StudentExtendedProxy newGroup);
		void DeleteStudent(StudentBasedProxy student);

		void AddUser(UserExtendedProxy user);
		void EditUser(UserExtendedProxy oldUser, UserExtendedProxy newUser);
		void DeleteUser(UserBasedProxy user);
	}
}