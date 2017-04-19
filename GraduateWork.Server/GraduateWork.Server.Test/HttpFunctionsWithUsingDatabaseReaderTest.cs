using System;
using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Functions.Protected.WithReturn.Database;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseReaderTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseReader databaseReader;

		[SetUp]
		public void SetUp() {
			databaseReader = A.Fake<IDatabaseReader>();
		}

		[Test]
		public void GetAllDisciplinesFunctionTest_ShouldBeSuccess() {
			var inputDisciplines = new[] {
				new DisciplineBasedProxy { DisciplineName = "firstNameOfDiscipline" },
				new DisciplineBasedProxy { DisciplineName = "secondNameOfDiscipline" }
			};
			A.CallTo(() => databaseReader.GetAllDisciplines()).Returns(inputDisciplines);

			RunServer(new GetAllDisciplinesFunction(DatabaseAuthorizer, databaseReader));
			var receivedDisciplines = SendRequest<DisciplineExtendedProxy[]>("GetAllDisciplines", GetDefaultParameters());

			A.CallTo(() => databaseReader.GetAllDisciplines()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputDisciplines, receivedDisciplines);
		}

		[Test]
		public void GetAllGroupsFunctionTest_ShouldBeSuccess() {
			var inputGroups = new[] {
				new GroupBasedProxy { GroupName = "firstNameOfGroup" },
				new GroupBasedProxy { GroupName = "secondNameOfGroup" }
			};
			A.CallTo(() => databaseReader.GetAllGroups()).Returns(inputGroups);

			RunServer(new GetAllGroupsFunction(DatabaseAuthorizer, databaseReader));
			var receivedGroups = SendRequest<GroupExtendedProxy[]>("GetAllGroups", GetDefaultParameters());

			A.CallTo(() => databaseReader.GetAllGroups()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputGroups, receivedGroups);
		}

		[Test]
		public void GetAllStudentsFunctionTest_ShouldBeSuccess() {
			var inputStudents = new[] {
				new StudentBasedProxy { FirstName = "firstFirstName" },
				new StudentBasedProxy { FirstName = "secondFirstName" }
			};
			A.CallTo(() => databaseReader.GetAllStudents()).Returns(inputStudents);

			RunServer(new GetAllStudentsFunction(DatabaseAuthorizer, databaseReader));
			var receivedStudents = SendRequest<StudentExtendedProxy[]>("GetAllStudents", GetDefaultParameters());

			A.CallTo(() => databaseReader.GetAllStudents()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputStudents, receivedStudents);
		}

		[Test]
		public void GetAllUsersFunctionTest_ShouldBeSuccess() {
			var inputUsers = new[] {
				new UserBasedProxy { Login = "firstLogin" },
				new UserBasedProxy { Login = "secondLogin" }
			};
			A.CallTo(() => databaseReader.GetAllUsers()).Returns(inputUsers);

			RunServer(new GetAllUsersFunction(DatabaseAuthorizer, databaseReader));
			var receivedUsers = SendRequest<UserBasedProxy[]>("GetAllUsers", GetDefaultParameters());

			A.CallTo(() => databaseReader.GetAllUsers()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputUsers, receivedUsers);
		}

		[Test]
		public void GetDisciplinesWithUsingFiltersFunctionTest_ShouldBeSuccess() {
			var disciplineName = "disciplineName";
			var controlType = ControlType.CourseWork;
			var groupName = "groupName";
			var inputDiscipline = new[] {
				new DisciplineBasedProxy { DisciplineName = "firstNameOfDiscipline" },
				new DisciplineBasedProxy { DisciplineName = "secondNameOfDiscipline" }
			};
			A.CallTo(() => databaseReader.GetDisciplinesWithUsingFilters(disciplineName, controlType, groupName)).Returns(inputDiscipline);

			RunServer(new GetDisciplinesWithUsingFiltersFunction(DatabaseAuthorizer, databaseReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.DisciplineName] = disciplineName;
			parameters[HttpParameters.ControlType] = controlType.ToString();
			parameters[HttpParameters.GroupName] = groupName;
			var receivedDisciplines = SendRequest<DisciplineExtendedProxy[]>("GetDisciplinesWithUsingFilters", parameters);

			A.CallTo(() => databaseReader.GetDisciplinesWithUsingFilters(disciplineName, controlType, groupName)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputDiscipline, receivedDisciplines);
		}

		[Test]
		public void GetGroupsWithUsingFiltersFunctionTest_ShouldBeSuccess() {
			var groupName = "groupName";
			var specialtyNumber = 123;
			var specialtyName = "specialtyName";
			var facultyName = "facultyName";
			var inputGroups = new[] {
				new GroupBasedProxy { GroupName = "firstNameOfGroup" },
				new GroupBasedProxy { GroupName = "secondNameOfGroup" }
			};
			A.CallTo(() => databaseReader.GetGroupsWithUsingFilters(groupName, specialtyNumber, specialtyName, facultyName)).Returns(inputGroups);

			RunServer(new GetGroupsWithUsingFiltersFunction(DatabaseAuthorizer, databaseReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.GroupName] = groupName;
			parameters[HttpParameters.SpecialtyNumber] = specialtyNumber.ToString();
			parameters[HttpParameters.SpecialtyName] = specialtyName;
			parameters[HttpParameters.FacultyName] = facultyName;
			var receivedGroups = SendRequest<GroupExtendedProxy[]>("GetGroupsWithUsingFilters", parameters);

			A.CallTo(() => databaseReader.GetGroupsWithUsingFilters(groupName, specialtyNumber, specialtyName, facultyName)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputGroups, receivedGroups);
		}

		[Test]
		public void GetStudentsWithUsingFiltersFunctionTest_ShouldBeSuccess() {
			var firstName = "firstName";
			var secondName = "secondName";
			var thirdName = "thirdName";
			var dateOfBirth = new DateTime(2000, 1, 1);
			var inputStudents = new[] {
				new StudentBasedProxy { FirstName = "firstFirstName" },
				new StudentBasedProxy { FirstName = "secondFirstName" }
			};
			A.CallTo(() => databaseReader.GetStudentsWithUsingFilters(firstName, secondName, thirdName, dateOfBirth)).Returns(inputStudents);

			RunServer(new GetStudentsWithUsingFiltersFunction(DatabaseAuthorizer, databaseReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.FirstName] = firstName;
			parameters[HttpParameters.SecondName] = secondName;
			parameters[HttpParameters.ThirdName] = thirdName;
			parameters[HttpParameters.DateOfBirth] = dateOfBirth.ToShortDateString();
			var receivedStudents = SendRequest<StudentExtendedProxy[]>("GetStudentsWithUsingFilters", parameters);

			A.CallTo(() => databaseReader.GetStudentsWithUsingFilters(firstName, secondName, thirdName, dateOfBirth)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputStudents, receivedStudents);
		}

		[Test]
		public void GetUsersWithUsingFiltersFunctionTest_ShouldBeSuccess() {
			var login = "login";
			var inputUsers = new[] {
				new UserBasedProxy { Login = "firstLogin" },
				new UserBasedProxy { Login = "secondLogin" }
			};
			A.CallTo(() => databaseReader.GetUsersWithUsingFilters(login)).Returns(inputUsers);

			RunServer(new GetUsersWithUsingFiltersFunction(DatabaseAuthorizer, databaseReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.LoginForFilter] = login;
			var receivedUsers = SendRequest<UserBasedProxy[]>("GetUsersWithUsingFilters", parameters);

			A.CallTo(() => databaseReader.GetUsersWithUsingFilters(login)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputUsers, receivedUsers);
		}

		[Test]
		public void GetExtendedDisciplineFunctionTest_ShouldBeSuccess() {
			var inputBasedDiscipline = new DisciplineBasedProxy { DisciplineName = "firstDiscipline" };
			var inputExtendedDiscipline = new DisciplineExtendedProxy { DisciplineName = "firstDiscipline" };
			A.CallTo(() => databaseReader.GetExtendedDiscipline(inputBasedDiscipline)).Returns(inputExtendedDiscipline);

			RunServer(new GetExtendedDisciplineFunction(DatabaseAuthorizer, databaseReader));
			var receivedDiscipline = SendRequest<DisciplineExtendedProxy>("GetExtendedDiscipline", GetDefaultParameters(), inputBasedDiscipline.ToJson());

			A.CallTo(() => databaseReader.GetExtendedDiscipline(inputBasedDiscipline)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedDiscipline, Is.EqualTo(inputExtendedDiscipline));
		}

		[Test]
		public void GetExtendedGroupFunctionTest_ShouldBeSuccess() {
			var inputBasedGroup = new GroupBasedProxy { GroupName = "firstGroup" };
			var inputExtendedGroup = new GroupExtendedProxy { GroupName = "firstGroup" };
			A.CallTo(() => databaseReader.GetExtendedGroup(inputBasedGroup)).Returns(inputExtendedGroup);

			RunServer(new GetExtendedGroupFunction(DatabaseAuthorizer, databaseReader));
			var receivedGroup = SendRequest<GroupExtendedProxy>("GetExtendedGroup", GetDefaultParameters(), inputBasedGroup.ToJson());

			A.CallTo(() => databaseReader.GetExtendedGroup(inputBasedGroup)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedGroup, Is.EqualTo(inputExtendedGroup));
		}

		[Test]
		public void GetExtendedStudentFunctionTest_ShouldBeSuccess() {
			var inputBasedStudent = new StudentBasedProxy { FirstName = "firstName" };
			var inputExtendedStudent = new StudentExtendedProxy { FirstName = "firstName" };
			A.CallTo(() => databaseReader.GetExtendedStudent(inputBasedStudent)).Returns(inputExtendedStudent);

			RunServer(new GetExtendedStudentFunction(DatabaseAuthorizer, databaseReader));
			var receivedStudent = SendRequest<StudentExtendedProxy>("GetExtendedStudent", GetDefaultParameters(), inputBasedStudent.ToJson());

			A.CallTo(() => databaseReader.GetExtendedStudent(inputBasedStudent)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedStudent, Is.EqualTo(inputExtendedStudent));
		}

		[Test]
		public void GetExtendedUserFunctionTest_ShouldBeSuccess() {
			var inputBasedUser = new UserBasedProxy { Login = "login" };
			var inputExtendedUser = new UserExtendedProxy { Login = "login" };
			A.CallTo(() => databaseReader.GetExtendedUser(inputBasedUser)).Returns(inputExtendedUser);

			RunServer(new GetExtendedUserFunction(DatabaseAuthorizer, databaseReader));
			var receivedUser = SendRequest<UserExtendedProxy>("GetExtendedUser", GetDefaultParameters(), inputBasedUser.ToJson());

			A.CallTo(() => databaseReader.GetExtendedUser(inputBasedUser)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedUser, Is.EqualTo(inputExtendedUser));
		}

		[Test]
		public void GetDisciplineNamesFromGroupNameFunctionTest_ShouldBeSuccess() {
			var groupName = "firstGroup";
			var inputAssessmentByDisciplines = new[] {
				new AssessmentByDiscipline { NameOfDiscipline = "firstDiscipline" },
				new AssessmentByDiscipline { NameOfDiscipline = "secondDiscipline" }
			};
			A.CallTo(() => databaseReader.GetAssessmentByDisciplinesFromGroupName(groupName)).Returns(inputAssessmentByDisciplines);

			RunServer(new GetAssessmentByDisciplinesFromGroupNameFunction(DatabaseAuthorizer, databaseReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.GroupName] = groupName;
			var receivedAssessmentByDisciplines = SendRequest<AssessmentByDiscipline[]>("GetAssessmentByDisciplinesFromGroupName", parameters);

			A.CallTo(() => databaseReader.GetAssessmentByDisciplinesFromGroupName(groupName)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputAssessmentByDisciplines, receivedAssessmentByDisciplines);
		}
	}
}