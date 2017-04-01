using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Server.Common.Database {
	public interface IDatabaseReader {
		DisciplineBasedProxy[] GetAllDisciplines();
		GroupBasedProxy[] GetAllGroups();
		StudentBasedProxy[] GetAllStudents();
	}
}