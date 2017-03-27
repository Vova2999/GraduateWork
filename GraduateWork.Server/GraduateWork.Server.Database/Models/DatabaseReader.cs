using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Database.Extensions;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseReader : IDatabaseReader {
		private readonly ModelDatabase modelDatabase;

		public DatabaseReader(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public GroupProxy[] GetAllGroups() {
			return modelDatabase.Groups.ToProxies();
		}
		public DisciplineProxy[] GetAllDisciplines() {
			return modelDatabase.Disciplines.ToProxies();
		}
		public StudentProxy[] GetAllStudents() {
			return modelDatabase.Students.ToProxies();
		}
	}
}