using System;
using System.Linq;
using System.Linq.Expressions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Database.Extensions;
using GraduateWork.Server.Database.Tables;
using AssessmentByDiscipline = GraduateWork.Common.Tables.Proxies.Extendeds.AssessmentByDiscipline;

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

		public DisciplineBasedProxy[] GetDisciplinesWithUsingFilters(string disciplineName, ControlType? controlType, string groupName) {
			IQueryable<Discipline> disciplines = modelDatabase.Disciplines;
			UseFilter(disciplineName != null, ref disciplines, discipline => discipline.DisciplineName.Contains(disciplineName));
			UseFilter(controlType != null, ref disciplines, discipline => discipline.ControlType == controlType);
			UseFilter(groupName != null, ref disciplines, discipline => discipline.Group.GroupName.Contains(groupName));

			return disciplines.ToBasedProxies();
		}
		public GroupBasedProxy[] GetGroupsWithUsingFilters(string groupName, int? specialtyNumber, string specialtyName, string facultyName) {
			IQueryable<Group> groups = modelDatabase.Groups;
			UseFilter(groupName != null, ref groups, group => group.GroupName.Contains(groupName));
			UseFilter(specialtyNumber != null, ref groups, group => group.SpecialtyNumber == specialtyNumber);
			UseFilter(specialtyName != null, ref groups, group => group.SpecialtyName.Contains(specialtyName));
			UseFilter(facultyName != null, ref groups, group => group.FacultyName.Contains(facultyName));

			return groups.ToBasedProxies();
		}
		public StudentBasedProxy[] GetStudentsWithUsingFilters(string firstName, string secondName, string thirdName, DateTime? dateOfBirth) {
			IQueryable<Student> students = modelDatabase.Students;
			UseFilter(firstName != null, ref students, student => student.FirstName.Contains(firstName));
			UseFilter(secondName != null, ref students, student => student.SecondName.Contains(secondName));
			UseFilter(thirdName != null, ref students, student => student.ThirdName.Contains(thirdName));
			UseFilter(dateOfBirth != null, ref students, student => student.DateOfBirth == dateOfBirth);

			return students.ToBasedProxies();
		}
		public UserBasedProxy[] GetUsersWithUsingFilters(string login) {
			IQueryable<User> users = modelDatabase.Users;
			UseFilter(login != null, ref users, user => user.Login.Contains(login));

			return users.ToBasedProxies();
		}
		private void UseFilter<TTable>(bool useFilter, ref IQueryable<TTable> table, Expression<Func<TTable, bool>> predicate) {
			table = useFilter ? table.Where(predicate) : table;
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