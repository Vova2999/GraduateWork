using FakeItEasy;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test.HttpFunctionsWithUsingDatabaseReaderTests {
	public class HttpFunctionsWithUsingDatabaseDisciplineReaderTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseDisciplineReader databaseDisciplineReader;

		[SetUp]
		public void SetUp() {
			databaseDisciplineReader = A.Fake<IDatabaseDisciplineReader>();
		}

		[Test]
		public void GetAllDisciplinesFunctionTest_ShouldBeSuccess() {
			var inputDisciplines = new[] {
				new DisciplineBasedProxy { DisciplineName = "firstNameOfDiscipline" },
				new DisciplineBasedProxy { DisciplineName = "secondNameOfDiscipline" }
			};
			A.CallTo(() => databaseDisciplineReader.GetAllBasedProies()).Returns(inputDisciplines);

			RunServer(new GetAllDisciplinesFunction(DatabaseAuthorizer, databaseDisciplineReader));
			var receivedDisciplines = SendRequest<DisciplineExtendedProxy[]>("GetAllDisciplines", GetDefaultParameters());

			A.CallTo(() => databaseDisciplineReader.GetAllBasedProies()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputDisciplines, receivedDisciplines);
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
			A.CallTo(() => databaseDisciplineReader.GetDisciplinesWithUsingFilters(disciplineName, controlType, groupName)).Returns(inputDiscipline);

			RunServer(new GetDisciplinesWithUsingFiltersFunction(DatabaseAuthorizer, databaseDisciplineReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.DisciplineName] = disciplineName;
			parameters[HttpParameters.ControlType] = controlType.ToString();
			parameters[HttpParameters.GroupName] = groupName;
			var receivedDisciplines = SendRequest<DisciplineExtendedProxy[]>("GetDisciplinesWithUsingFilters", parameters);

			A.CallTo(() => databaseDisciplineReader.GetDisciplinesWithUsingFilters(disciplineName, controlType, groupName)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputDiscipline, receivedDisciplines);
		}

		[Test]
		public void GetExtendedDisciplineFunctionTest_ShouldBeSuccess() {
			var inputBasedDiscipline = new DisciplineBasedProxy { DisciplineName = "firstDiscipline" };
			var inputExtendedDiscipline = new DisciplineExtendedProxy { DisciplineName = "firstDiscipline" };
			A.CallTo(() => databaseDisciplineReader.GetExtendedProxy(inputBasedDiscipline)).Returns(inputExtendedDiscipline);

			RunServer(new GetExtendedDisciplineFunction(DatabaseAuthorizer, databaseDisciplineReader));
			var receivedDiscipline = SendRequest<DisciplineExtendedProxy>("GetExtendedDiscipline", GetDefaultParameters(), inputBasedDiscipline.ToJson());

			A.CallTo(() => databaseDisciplineReader.GetExtendedProxy(inputBasedDiscipline)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedDiscipline, Is.EqualTo(inputExtendedDiscipline));
		}
	}
}