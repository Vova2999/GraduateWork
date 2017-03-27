using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Server.Common.Database {
	public interface IDatabaseReader {
		GroupProxy[] GetAllGroups();
		StudentProxy[] GetAllStudents();
		DisciplineProxy[] GetAllDisciplines();
	}
}