using System;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Server.Common.Database {
	public interface IDatabaseReader {
		AssessmentByDiscipline[] GetAssessmentByDisciplinesFromGroupName(string groupName);

		DisciplineBasedProxy[] GetAllDisciplines();
		GroupBasedProxy[] GetAllGroups();
		StudentBasedProxy[] GetAllStudents();
		UserBasedProxy[] GetAllUsers();

		DisciplineBasedProxy[] GetDisciplinesWithUsingFilters(string disciplineName, ControlType? controlType, string groupName);
		GroupBasedProxy[] GetGroupsWithUsingFilters(string groupName, int? specialtyNumber, string specialtyName, string facultyName);
		StudentBasedProxy[] GetStudentsWithUsingFilters(string firstName, string secondName, string thirdName, DateTime? dateOfBirth);
		UserBasedProxy[] GetUsersWithUsingFilters(string login);

		DisciplineExtendedProxy GetExtendedDiscipline(DisciplineBasedProxy discipline);
		GroupExtendedProxy GetExtendedGroup(GroupBasedProxy group);
		StudentExtendedProxy GetExtendedStudent(StudentBasedProxy student);
		UserExtendedProxy GetExtendedUser(UserBasedProxy user);
	}
}