using FakeItEasy;
using GraduateWork.Common.Tables.Proxies;
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
				new UserProxy { Login = "firstLogin" },
				new UserProxy { Login = "secondLogin" }
			};
			A.CallTo(() => databaseReader.GetAllUsers()).Returns(inputUsers);

			RunServer(new GetAllUsersFunction(DatabaseAuthorizer, databaseReader));
			var receivedUsers = SendRequest<UserProxy[]>("GetAllUsers", DefaultParameters);

			A.CallTo(() => databaseReader.GetAllUsers()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputUsers, receivedUsers);
		}
	}
}