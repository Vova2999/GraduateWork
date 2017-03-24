using System;
using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common;
using GraduateWork.Server.Functions.FunctionsWithoutReturn;
using GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Add;
using GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Delete;
using GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Edit;
using GraduateWork.Server.Functions.FunctionsWithReturn;
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

			A.CallTo(() => modelDatabase
				.AddDiscipline(A<DisciplineProxy>.That.Matches(d => d.NameOfDiscipline == discipline.NameOfDiscipline)))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupProxy { NameOfGroup = "nameOfGroup" };

			RunServer(new AddGroupFunction(modelDatabase));
			SendRequest("AddGroup", group.ToJson());

			A.CallTo(() => modelDatabase
				.AddGroup(A<GroupProxy>.That.Matches(g => g.NameOfGroup == group.NameOfGroup)))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void AddStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };

			RunServer(new AddStudentFunction(modelDatabase));
			SendRequest("AddStudent", student.ToJson());

			A.CallTo(() => modelDatabase
				.AddStudent(A<StudentProxy>.That.Matches(s => s.FirstName == student.FirstName)))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteDisciplineFunctionTest_ShouldBeSuccess() {
			var discipline = new DisciplineProxy { NameOfDiscipline = "nameOfDiscipline" };

			RunServer(new DeleteDisciplineFunction(modelDatabase));
			SendRequest("DeleteDiscipline", discipline.ToJson());

			A.CallTo(() => modelDatabase
				.DeleteDiscipline(A<DisciplineProxy>.That.Matches(d => d.NameOfDiscipline == discipline.NameOfDiscipline)))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupProxy { NameOfGroup = "nameOfGroup" };

			RunServer(new DeleteGroupFunction(modelDatabase));
			SendRequest("DeleteGroup", group.ToJson());

			A.CallTo(() => modelDatabase
				.DeleteGroup(A<GroupProxy>.That.Matches(g => g.NameOfGroup == group.NameOfGroup)))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };

			RunServer(new DeleteStudentFunction(modelDatabase));
			SendRequest("DeleteStudent", student.ToJson());

			A.CallTo(() => modelDatabase
				.DeleteStudent(A<StudentProxy>.That.Matches(s => s.FirstName == student.FirstName)))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditDisciplineFunctionTest_ShouldBeSuccess() {
			var firstDiscipline = new DisciplineProxy { NameOfDiscipline = "firstNameOfDiscipline" };
			var secondDiscipline = new DisciplineProxy { NameOfDiscipline = "secondNameOfDiscipline" };

			RunServer(new EditDisciplineFunction(modelDatabase));
			SendRequest("EditDiscipline", Tuple.Create(firstDiscipline, secondDiscipline).ToJson());

			A.CallTo(() => modelDatabase
				.EditDiscipline(
					A<DisciplineProxy>.That.Matches(f => f.NameOfDiscipline == firstDiscipline.NameOfDiscipline),
					A<DisciplineProxy>.That.Matches(s => s.NameOfDiscipline == secondDiscipline.NameOfDiscipline)))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditGroupFunctionTest_ShouldBeSuccess() {
			var firstGroup = new GroupProxy { NameOfGroup = "firstNameOfGroup" };
			var secondGroup = new GroupProxy { NameOfGroup = "secondNameOfGroup" };

			RunServer(new EditGroupFunction(modelDatabase));
			SendRequest("EditGroup", Tuple.Create(firstGroup, secondGroup).ToJson());

			A.CallTo(() => modelDatabase
				.EditGroup(
					A<GroupProxy>.That.Matches(f => f.NameOfGroup == firstGroup.NameOfGroup),
					A<GroupProxy>.That.Matches(s => s.NameOfGroup == secondGroup.NameOfGroup)))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditStudentFunctionTest_ShouldBeSuccess() {
			var firstStudent = new StudentProxy { FirstName = "firstFirstName" };
			var secondStudent = new StudentProxy { FirstName = "secondFirstName" };

			RunServer(new EditStudentFunction(modelDatabase));
			SendRequest("EditStudent", Tuple.Create(firstStudent, secondStudent).ToJson());

			A.CallTo(() => modelDatabase
				.EditStudent(
					A<StudentProxy>.That.Matches(f => f.FirstName == firstStudent.FirstName),
					A<StudentProxy>.That.Matches(s => s.FirstName == secondStudent.FirstName)))
				.MustHaveHappened(Repeated.Exactly.Once);
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

		[Test]
		public void GetAllStudentsFormGroupByNameFunctionTest_ShouldBeSuccess() {
			const string nameOfGroup = "qwert";
			var inputStudents = new[] {
				new StudentProxy { FirstName = "firstFirstName" },
				new StudentProxy { NameOfGroup = "secondFirstName" }
			};
			A.CallTo(() => modelDatabase.GetAllStudentsFormGroupByName(nameOfGroup)).Returns(inputStudents);

			RunServer(new GetAllStudentsFormGroupByNameFunction(modelDatabase));
			var receivedStudents = SendRequest<StudentProxy[]>($"GetAllStudentsFormGroupByName?NameOfGroup={nameOfGroup}");

			A.CallTo(() => modelDatabase.GetAllStudentsFormGroupByName(nameOfGroup)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputStudents, receivedStudents);
		}
	}
}