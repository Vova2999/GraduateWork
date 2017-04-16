using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Server.Common.Database {
	public interface IDatabaseReader {
		AssessmentByDiscipline[] GetAssessmentByDisciplinesFromGroupName(string groupName);

		DisciplineBasedProxy[] GetAllDisciplines();
		GroupBasedProxy[] GetAllGroups();
		StudentBasedProxy[] GetAllStudents();
		UserBasedProxy[] GetAllUsers();

		DisciplineExtendedProxy GetExtendedDiscipline(DisciplineBasedProxy discipline);
		GroupExtendedProxy GetExtendedGroup(GroupBasedProxy group);
		StudentExtendedProxy GetExtendedStudent(StudentBasedProxy student);
		UserExtendedProxy GetExtendedUser(UserBasedProxy user);
	}
}