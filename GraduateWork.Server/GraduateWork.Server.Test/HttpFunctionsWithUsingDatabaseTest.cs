using System;
using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Functions.WithoutReturn;
using GraduateWork.Server.Functions.WithoutReturn.Database.Add;
using GraduateWork.Server.Functions.WithoutReturn.Database.Delete;
using GraduateWork.Server.Functions.WithoutReturn.Database.Edit;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseEditorTest : HttpFunctionsTest {
		private IDatabaseEditor databaseEditor;

		[SetUp]
		public void SetUp() {
			databaseEditor = A.Fake<IDatabaseEditor>();
		}

		[Test]
		public void PingFunctionTest_ShouldBeSuccess() {
			RunServer(new PingFunction());
			SendRequest("Ping");
		}

		[Test]
		public void AddDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineProxy { NameOfDiscipline = "nameOfDiscipline" };

			RunServer(new AddDisciplineFunction(databaseEditor));
			SendRequest("AddDiscipline", discipline.ToJson());

			A.CallTo(() => databaseEditor.AddDiscipline(discipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupProxy { NameOfGroup = "nameOfGroup" };

			RunServer(new AddGroupFunction(databaseEditor));
			SendRequest("AddGroup", group.ToJson());

			A.CallTo(() => databaseEditor.AddGroup(group)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };

			RunServer(new AddStudentFunction(databaseEditor));
			SendRequest("AddStudent", student.ToJson());

			A.CallTo(() => databaseEditor.AddStudent(student)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineProxy { NameOfDiscipline = "nameOfDiscipline" };

			RunServer(new DeleteDisciplineFunction(databaseEditor));
			SendRequest("DeleteDiscipline", discipline.ToJson());

			A.CallTo(() => databaseEditor.DeleteDiscipline(discipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupProxy { NameOfGroup = "nameOfGroup" };

			RunServer(new DeleteGroupFunction(databaseEditor));
			SendRequest("DeleteGroup", group.ToJson());

			A.CallTo(() => databaseEditor.DeleteGroup(group)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };

			RunServer(new DeleteStudentFunction(databaseEditor));
			SendRequest("DeleteStudent", student.ToJson());

			A.CallTo(() => databaseEditor.DeleteStudent(student)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditDisciplineFunctionTest_ShouldBeSuccess() {
			var firstDiscipline = new DisciplineProxy { NameOfDiscipline = "firstNameOfDiscipline" };
			var secondDiscipline = new DisciplineProxy { NameOfDiscipline = "secondNameOfDiscipline" };

			RunServer(new EditDisciplineFunction(databaseEditor));
			SendRequest("EditDiscipline", Tuple.Create(firstDiscipline, secondDiscipline).ToJson());

			A.CallTo(() => databaseEditor.EditDiscipline(firstDiscipline, secondDiscipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditGroupFunctionTest_ShouldBeSuccess() {
			var firstGroup = new GroupProxy { NameOfGroup = "firstNameOfGroup" };
			var secondGroup = new GroupProxy { NameOfGroup = "secondNameOfGroup" };

			RunServer(new EditGroupFunction(databaseEditor));
			SendRequest("EditGroup", Tuple.Create(firstGroup, secondGroup).ToJson());

			A.CallTo(() => databaseEditor.EditGroup(firstGroup, secondGroup)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditStudentFunctionTest_ShouldBeSuccess() {
			var firstStudent = new StudentProxy { FirstName = "firstFirstName" };
			var secondStudent = new StudentProxy { FirstName = "secondFirstName" };

			RunServer(new EditStudentFunction(databaseEditor));
			SendRequest("EditStudent", Tuple.Create(firstStudent, secondStudent).ToJson());

			A.CallTo(() => databaseEditor.EditStudent(firstStudent, secondStudent)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}