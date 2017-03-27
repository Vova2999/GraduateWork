using System;
using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common;
using GraduateWork.Server.Functions.WithoutReturn;
using GraduateWork.Server.Functions.WithoutReturn.Database.Add;
using GraduateWork.Server.Functions.WithoutReturn.Database.Delete;
using GraduateWork.Server.Functions.WithoutReturn.Database.Edit;
using GraduateWork.Server.Functions.WithReturn.Database;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseTest : HttpFunctionsTest {
		private IModelDatabase modelDatabase;

		[SetUp]
		public void SetUp() {
			modelDatabase = A.Fake<IModelDatabase>();
		}

		[Test]
		public void PingFunctionTest_ShouldBeSuccess() {
			RunServer(new PingFunction());
			SendRequest("Ping");
		}

		[Test]
		public void AddDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineProxy { NameOfDiscipline = "nameOfDiscipline" };

			RunServer(new AddDisciplineFunction(modelDatabase));
			SendRequest("AddDiscipline", discipline.ToJson());

			A.CallTo(() => modelDatabase.AddDiscipline(discipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupProxy { NameOfGroup = "nameOfGroup" };

			RunServer(new AddGroupFunction(modelDatabase));
			SendRequest("AddGroup", group.ToJson());

			A.CallTo(() => modelDatabase.AddGroup(group)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };

			RunServer(new AddStudentFunction(modelDatabase));
			SendRequest("AddStudent", student.ToJson());

			A.CallTo(() => modelDatabase.AddStudent(student)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineProxy { NameOfDiscipline = "nameOfDiscipline" };

			RunServer(new DeleteDisciplineFunction(modelDatabase));
			SendRequest("DeleteDiscipline", discipline.ToJson());

			A.CallTo(() => modelDatabase.DeleteDiscipline(discipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupProxy { NameOfGroup = "nameOfGroup" };

			RunServer(new DeleteGroupFunction(modelDatabase));
			SendRequest("DeleteGroup", group.ToJson());

			A.CallTo(() => modelDatabase.DeleteGroup(group)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };

			RunServer(new DeleteStudentFunction(modelDatabase));
			SendRequest("DeleteStudent", student.ToJson());

			A.CallTo(() => modelDatabase.DeleteStudent(student)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditDisciplineFunctionTest_ShouldBeSuccess() {
			var firstDiscipline = new DisciplineProxy { NameOfDiscipline = "firstNameOfDiscipline" };
			var secondDiscipline = new DisciplineProxy { NameOfDiscipline = "secondNameOfDiscipline" };

			RunServer(new EditDisciplineFunction(modelDatabase));
			SendRequest("EditDiscipline", Tuple.Create(firstDiscipline, secondDiscipline).ToJson());

			A.CallTo(() => modelDatabase.EditDiscipline(firstDiscipline, secondDiscipline)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditGroupFunctionTest_ShouldBeSuccess() {
			var firstGroup = new GroupProxy { NameOfGroup = "firstNameOfGroup" };
			var secondGroup = new GroupProxy { NameOfGroup = "secondNameOfGroup" };

			RunServer(new EditGroupFunction(modelDatabase));
			SendRequest("EditGroup", Tuple.Create(firstGroup, secondGroup).ToJson());

			A.CallTo(() => modelDatabase.EditGroup(firstGroup, secondGroup)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditStudentFunctionTest_ShouldBeSuccess() {
			var firstStudent = new StudentProxy { FirstName = "firstFirstName" };
			var secondStudent = new StudentProxy { FirstName = "secondFirstName" };

			RunServer(new EditStudentFunction(modelDatabase));
			SendRequest("EditStudent", Tuple.Create(firstStudent, secondStudent).ToJson());

			A.CallTo(() => modelDatabase.EditStudent(firstStudent, secondStudent)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void GetAllDisciplinesFunctionTest_ShouldBeSuccess() {
			var inputDiscipline = new[] {
				new DisciplineProxy { NameOfDiscipline = "firstNameOfDiscipline" },
				new DisciplineProxy { NameOfDiscipline = "secondNameOfDiscipline" }
			};
			A.CallTo(() => modelDatabase.GetAllDisciplines()).Returns(inputDiscipline);

			RunServer(new GetAllDisciplinesFunction(modelDatabase));
			var receivedDisciplines = SendRequest<DisciplineProxy[]>("GetAllDisciplines");

			A.CallTo(() => modelDatabase.GetAllDisciplines()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputDiscipline, receivedDisciplines);
		}

		[Test]
		public void GetAllGroupsFunctionTest_ShouldBeSuccess() {
			var inputGroups = new[] {
				new GroupProxy { NameOfGroup = "firstNameOfGroup" },
				new GroupProxy { NameOfGroup = "secondNameOfGroup" }
			};
			A.CallTo(() => modelDatabase.GetAllGroups()).Returns(inputGroups);

			RunServer(new GetAllGroupsFunction(modelDatabase));
			var receivedGroups = SendRequest<GroupProxy[]>("GetAllGroups");

			A.CallTo(() => modelDatabase.GetAllGroups()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputGroups, receivedGroups);
		}

		[Test]
		public void GetAllStudentsFunctionTest_ShouldBeSuccess() {
			var inputStudents = new[] {
				new StudentProxy { FirstName = "firstFirstName" },
				new StudentProxy { NameOfGroup = "secondFirstName" }
			};
			A.CallTo(() => modelDatabase.GetAllStudents()).Returns(inputStudents);

			RunServer(new GetAllStudentsFunction(modelDatabase));
			var receivedStudents = SendRequest<StudentProxy[]>("GetAllStudents");

			A.CallTo(() => modelDatabase.GetAllStudents()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputStudents, receivedStudents);
		}
	}
}