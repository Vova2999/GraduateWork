using System;
using FakeItEasy;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Discipline;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test.HttpFunctionsWithUsingDatabaseEditorTests {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseDisciplineEditorTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseDisciplineEditor databaseDisciplineEditor;

		[SetUp]
		public void SetUp() {
			databaseDisciplineEditor = A.Fake<IDatabaseDisciplineEditor>();
		}

		[Test]
		public void AddDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineExtendedProxy { DisciplineName = "nameOfDiscipline" };

			RunServer(new AddDisciplineFunction(DatabaseAuthorizer, databaseDisciplineEditor));
			SendRequest("AddDiscipline", GetDefaultParameters(), discipline.ToJson());

			A.CallTo(() => databaseDisciplineEditor.Add(discipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineBasedProxy { DisciplineName = "nameOfDiscipline" };

			RunServer(new DeleteDisciplineFunction(DatabaseAuthorizer, databaseDisciplineEditor));
			SendRequest("DeleteDiscipline", GetDefaultParameters(), discipline.ToJson());

			A.CallTo(() => databaseDisciplineEditor.Delete(discipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditDisciplineFunctionTest_ShouldBeSuccess() {
			var firstDiscipline = new DisciplineExtendedProxy { DisciplineName = "firstNameOfDiscipline" };
			var secondDiscipline = new DisciplineExtendedProxy { DisciplineName = "secondNameOfDiscipline" };

			RunServer(new EditDisciplineFunction(DatabaseAuthorizer, databaseDisciplineEditor));
			SendRequest("EditDiscipline", GetDefaultParameters(), Tuple.Create(firstDiscipline, secondDiscipline).ToJson());

			A.CallTo(() => databaseDisciplineEditor.Edit(firstDiscipline, secondDiscipline)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}