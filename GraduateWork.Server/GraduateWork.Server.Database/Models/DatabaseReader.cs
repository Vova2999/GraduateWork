using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Common.Tables.Proxies.Baseds;
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
		public UserProxy[] GetAllUsers() {
			return modelDatabase.Users.ToProxies();
		}
	}
}