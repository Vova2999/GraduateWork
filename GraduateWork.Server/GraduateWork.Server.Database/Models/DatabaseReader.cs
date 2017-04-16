using System.Linq;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Database.Extensions;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable UnusedMember.Global

	public class DatabaseReader : IDatabaseReader {
		private readonly ModelDatabase modelDatabase;

		public DatabaseReader(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public AssessmentByDiscipline[] GetAssessmentByDisciplinesFromGroupName(string groupName) {
			return modelDatabase.GetGroup(groupName).Disciplines.Select(
				discipline => new AssessmentByDiscipline {
					NameOfDiscipline = discipline.DisciplineName,
					ControlType = discipline.ControlType,
					Assessment = Assessment.None
				}).ToArray();
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
		public GroupExtendedProxy GetExtendedGroup(GroupBasedProxy group) {
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