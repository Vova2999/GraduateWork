using System;
using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Add;
using GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Delete;
using GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Edit;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseEditorTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseEditor databaseEditor;

		[SetUp]
		public void SetUp() {
			databaseEditor = A.Fake<IDatabaseEditor>();
		}

		[Test]
		public void AddDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineProxy { NameOfDiscipline = "nameOfDiscipline" };

			RunServer(new AddDisciplineFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("AddDiscipline", DefaultParameters, discipline.ToJson());

			A.CallTo(() => databaseEditor.AddDiscipline(discipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupProxy { NameOfGroup = "nameOfGroup" };

			RunServer(new AddGroupFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("AddGroup", DefaultParameters, group.ToJson());

			A.CallTo(() => databaseEditor.AddGroup(group)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };

			RunServer(new AddStudentFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("AddStudent", DefaultParameters, student.ToJson());

			A.CallTo(() => databaseEditor.AddStudent(student)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddUserFunctionTest_ShouldBeSuccess() {
			var user = new UserProxy { Login = "login" };

			RunServer(new AddUserFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("AddUser", DefaultParameters, user.ToJson());

			A.CallTo(() => databaseEditor.AddUser(user)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineProxy { NameOfDiscipline = "nameOfDiscipline" };

			RunServer(new DeleteDisciplineFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("DeleteDiscipline", DefaultParameters, discipline.ToJson());

			A.CallTo(() => databaseEditor.DeleteDiscipline(discipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupProxy { NameOfGroup = "nameOfGroup" };

			RunServer(new DeleteGroupFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("DeleteGroup", DefaultParameters, group.ToJson());

			A.CallTo(() => databaseEditor.DeleteGroup(group)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };

			RunServer(new DeleteStudentFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("DeleteStudent", DefaultParameters, student.ToJson());

			A.CallTo(() => databaseEditor.DeleteStudent(student)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteUserFunctionTest_ShouldBeSuccess() {
			var user = new UserProxy { Login = "login" };

			RunServer(new DeleteUserFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("DeleteUser", DefaultParameters, user.ToJson());

			A.CallTo(() => databaseEditor.DeleteUser(user)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditDisciplineFunctionTest_ShouldBeSuccess() {
			var firstDiscipline = new DisciplineProxy { NameOfDiscipline = "firstNameOfDiscipline" };
			var secondDiscipline = new DisciplineProxy { NameOfDiscipline = "secondNameOfDiscipline" };

			RunServer(new EditDisciplineFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("EditDiscipline", DefaultParameters, Tuple.Create(firstDiscipline, secondDiscipline).ToJson());

			A.CallTo(() => databaseEditor.EditDiscipline(firstDiscipline, secondDiscipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditGroupFunctionTest_ShouldBeSuccess() {
			var firstGroup = new GroupProxy { NameOfGroup = "firstNameOfGroup" };
			var secondGroup = new GroupProxy { NameOfGroup = "secondNameOfGroup" };

			RunServer(new EditGroupFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("EditGroup", DefaultParameters, Tuple.Create(firstGroup, secondGroup).ToJson());

			A.CallTo(() => databaseEditor.EditGroup(firstGroup, secondGroup)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditStudentFunctionTest_ShouldBeSuccess() {
			var firstStudent = new StudentProxy { FirstName = "firstFirstName" };
			var secondStudent = new StudentProxy { FirstName = "secondFirstName" };

			RunServer(new EditStudentFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("EditStudent", DefaultParameters, Tuple.Create(firstStudent, secondStudent).ToJson());

			A.CallTo(() => databaseEditor.EditStudent(firstStudent, secondStudent)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditUserFunctionTest_ShouldBeSuccess() {
			var firstUser = new UserProxy { Login = "firstLogin" };
			var secondUser = new UserProxy { Login = "secondLogin" };

			RunServer(new EditUserFunction(DatabaseAuthorizer, databaseEditor));
			SendRequest("EditUser", DefaultParameters, Tuple.Create(firstUser, secondUser).ToJson());

			A.CallTo(() => databaseEditor.EditUser(firstUser, secondUser)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}