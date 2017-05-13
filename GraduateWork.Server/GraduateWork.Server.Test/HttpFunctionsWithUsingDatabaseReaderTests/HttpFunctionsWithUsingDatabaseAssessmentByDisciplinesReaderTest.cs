using FakeItEasy;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Functions.Protected.WithReturn.Database;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test.HttpFunctionsWithUsingDatabaseReaderTests {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseAssessmentByDisciplinesReaderTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseAssessmentByDisciplinesReader databaseAssessmentByDisciplinesReader;

		[SetUp]
		public void SetUp() {
			databaseAssessmentByDisciplinesReader = A.Fake<IDatabaseAssessmentByDisciplinesReader>();
		}

		[Test]
		public void GetDisciplineNamesFromGroupNameFunctionTest_ShouldBeSuccess() {
			var groupName = "firstGroup";
			var inputAssessmentByDisciplines = new[] {
				new AssessmentByDiscipline { NameOfDiscipline = "firstDiscipline" },
				new AssessmentByDiscipline { NameOfDiscipline = "secondDiscipline" }
			};
			A.CallTo(() => databaseAssessmentByDisciplinesReader.GetAssessmentByDisciplinesFromGroupName(groupName)).Returns(inputAssessmentByDisciplines);

			RunServer(new GetAssessmentByDisciplinesFromGroupNameFunction(DatabaseAuthorizer, databaseAssessmentByDisciplinesReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.GroupName] = groupName;
			var receivedAssessmentByDisciplines = SendRequest<AssessmentByDiscipline[]>("GetAssessmentByDisciplinesFromGroupName", parameters);

			A.CallTo(() => databaseAssessmentByDisciplinesReader.GetAssessmentByDisciplinesFromGroupName(groupName)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputAssessmentByDisciplines, receivedAssessmentByDisciplines);
		}
	}
}