using FakeItEasy;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Functions.WithReturn.Database;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseReaderTest : HttpFunctionsTest {
		private IDatabaseReader databaseReader;

		[SetUp]
		public void SetUp() {
			databaseReader = A.Fake<IDatabaseReader>();
		}

		[Test]
		public void GetAllDisciplinesFunctionTest_ShouldBeSuccess() {
			var inputDiscipline = new[] {
				new DisciplineProxy { NameOfDiscipline = "firstNameOfDiscipline" },
				new DisciplineProxy { NameOfDiscipline = "secondNameOfDiscipline" }
			};
			A.CallTo(() => databaseReader.GetAllDisciplines()).Returns(inputDiscipline);

			RunServer(new GetAllDisciplinesFunction(databaseReader));
			var receivedDisciplines = SendRequest<DisciplineProxy[]>("GetAllDisciplines");

			A.CallTo(() => databaseReader.GetAllDisciplines()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputDiscipline, receivedDisciplines);
		}

		[Test]
		public void GetAllGroupsFunctionTest_ShouldBeSuccess() {
			var inputGroups = new[] {
				new GroupProxy { NameOfGroup = "firstNameOfGroup" },
				new GroupProxy { NameOfGroup = "secondNameOfGroup" }
			};
			A.CallTo(() => databaseReader.GetAllGroups()).Returns(inputGroups);

			RunServer(new GetAllGroupsFunction(databaseReader));
			var receivedGroups = SendRequest<GroupProxy[]>("GetAllGroups");

			A.CallTo(() => databaseReader.GetAllGroups()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputGroups, receivedGroups);
		}

		[Test]
		public void GetAllStudentsFunctionTest_ShouldBeSuccess() {
			var inputStudents = new[] {
				new StudentProxy { FirstName = "firstFirstName" },
				new StudentProxy { NameOfGroup = "secondFirstName" }
			};
			A.CallTo(() => databaseReader.GetAllStudents()).Returns(inputStudents);

			RunServer(new GetAllStudentsFunction(databaseReader));
			var receivedStudents = SendRequest<StudentProxy[]>("GetAllStudents");

			A.CallTo(() => databaseReader.GetAllStudents()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputStudents, receivedStudents);
		}
	}
}