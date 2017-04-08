using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Database.Extensions;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseReader : IDatabaseReader {
		private readonly ModelDatabase modelDatabase;

		public DatabaseReader(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public DisciplineBasedProxy[] GetAllDisciplines() {
			return modelDatabase.Disciplines.ToBasedProxies();
		}
		public GroupBasedProxy[] GetAllGroups() {
			return modelDatabase.Groups.ToBasedProxies();
		}
		public StudentBasedProxy[] GetAllStudents() {
			return modelDatabase.Students.ToBasedProxies();
		}
		public UserBasedProxy[] GetAllUsers() {
			return modelDatabase.Users.ToBasedProxies();
		}

		public DisciplineExtendedProxy GetExtendedDiscipline(DisciplineBasedProxy discipline) {
			return modelDatabase.GetDiscipline(discipline).ToExtendedProxy();
		}
		public GroupExtendedProxy GetExtendedGroup(GroupBasedProxy @group) {
			return modelDatabase.GetGroup(group).ToExtendedProxy();
		}
		public StudentExtendedProxy GetExtendedStudent(StudentBasedProxy student) {
			return modelDatabase.GetStudent(student).ToExtendedProxy();
		}
		public UserExtendedProxy GetExtendedUser(UserBasedProxy user) {
			return modelDatabase.GetUser(user).ToExtendedProxy();
		}
	}
}