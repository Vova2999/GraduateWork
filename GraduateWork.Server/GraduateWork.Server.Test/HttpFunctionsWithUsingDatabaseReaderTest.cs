using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Functions.Protected.WithReturn.Database;
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
			var inputDiscipline = new[] {
				new DisciplineBasedProxy { DisciplineName = "firstNameOfDiscipline" },
				new DisciplineBasedProxy { DisciplineName = "secondNameOfDiscipline" }
			};
			A.CallTo(() => databaseReader.GetAllDisciplines()).Returns(inputDiscipline);

			RunServer(new GetAllDisciplinesFunction(DatabaseAuthorizer, databaseReader));
			var receivedDisciplines = SendRequest<DisciplineExtendedProxy[]>("GetAllDisciplines", DefaultParameters);

			A.CallTo(() => databaseReader.GetAllDisciplines()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputDiscipline, receivedDisciplines);
		}

		[Test]
		public void GetAllGroupsFunctionTest_ShouldBeSuccess() {
			var inputGroups = new[] {
				new GroupBasedProxy { GroupName = "firstNameOfGroup" },
				new GroupBasedProxy { GroupName = "secondNameOfGroup" }
			};
			A.CallTo(() => databaseReader.GetAllGroups()).Returns(inputGroups);

			RunServer(new GetAllGroupsFunction(DatabaseAuthorizer, databaseReader));
			var receivedGroups = SendRequest<GroupExtendedProxy[]>("GetAllGroups", DefaultParameters);

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
			var receivedStudents = SendRequest<StudentExtendedProxy[]>("GetAllStudents", DefaultParameters);

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
			var receivedUsers = SendRequest<UserBasedProxy[]>("GetAllUsers", DefaultParameters);

			A.CallTo(() => databaseReader.GetAllUsers()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputUsers, receivedUsers);
		}

		[Test]
		public void GetExtendedDisciplineFunctionTest_ShouldBeSuccess() {
			var inputBasedDiscipline = new DisciplineBasedProxy { DisciplineName = "firstDiscipline" };
			var inputExtendedDiscipline = new DisciplineExtendedProxy { DisciplineName = "firstDiscipline" };
			A.CallTo(() => databaseReader.GetExtendedDiscipline(inputBasedDiscipline)).Returns(inputExtendedDiscipline);

			RunServer(new GetExtendedDisciplineFunction(DatabaseAuthorizer, databaseReader));
			var receivedDiscipline = SendRequest<DisciplineExtendedProxy>("GetExtendedDiscipline", DefaultParameters, inputBasedDiscipline.ToJson());

			A.CallTo(() => databaseReader.GetExtendedDiscipline(inputBasedDiscipline)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedDiscipline, Is.EqualTo(inputExtendedDiscipline));
		}

		[Test]
		public void GetExtendedGroupFunctionTest_ShouldBeSuccess() {
			var inputBasedGroup = new GroupBasedProxy { GroupName = "firstGroup" };
			var inputExtendedGroup = new GroupExtendedProxy { GroupName = "firstGroup" };
			A.CallTo(() => databaseReader.GetExtendedGroup(inputBasedGroup)).Returns(inputExtendedGroup);

			RunServer(new GetExtendedGroupFunction(DatabaseAuthorizer, databaseReader));
			var receivedGroup = SendRequest<GroupExtendedProxy>("GetExtendedGroup", DefaultParameters, inputBasedGroup.ToJson());

			A.CallTo(() => databaseReader.GetExtendedGroup(inputBasedGroup)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedGroup, Is.EqualTo(inputExtendedGroup));
		}

		[Test]
		public void GetExtendedStudentFunctionTest_ShouldBeSuccess() {
			var inputBasedStudent = new StudentBasedProxy { FirstName = "firstName" };
			var inputExtendedStudent = new StudentExtendedProxy { FirstName = "firstName" };
			A.CallTo(() => databaseReader.GetExtendedStudent(inputBasedStudent)).Returns(inputExtendedStudent);

			RunServer(new GetExtendedStudentFunction(DatabaseAuthorizer, databaseReader));
			var receivedStudent = SendRequest<StudentExtendedProxy>("GetExtendedStudent", DefaultParameters, inputBasedStudent.ToJson());

			A.CallTo(() => databaseReader.GetExtendedStudent(inputBasedStudent)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedStudent, Is.EqualTo(inputExtendedStudent));
		}

		[Test]
		public void GetExtendedUserFunctionTest_ShouldBeSuccess() {
			var inputBasedUser = new UserBasedProxy { Login = "login" };
			var inputExtendedUser = new UserExtendedProxy { Login = "login" };
			A.CallTo(() => databaseReader.GetExtendedUser(inputBasedUser)).Returns(inputExtendedUser);

			RunServer(new GetExtendedUserFunction(DatabaseAuthorizer, databaseReader));
			var receivedUser = SendRequest<UserExtendedProxy>("GetExtendedUser", DefaultParameters, inputBasedUser.ToJson());

			A.CallTo(() => databaseReader.GetExtendedUser(inputBasedUser)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedUser, Is.EqualTo(inputExtendedUser));
		}
	}
}