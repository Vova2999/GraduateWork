using System;
using FakeItEasy;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Student;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test.HttpFunctionsWithUsingDatabaseEditorTests {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseStudentEditorTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseStudentEditor databaseStudentEditor;

		[SetUp]
		public void SetUp() {
			databaseStudentEditor = A.Fake<IDatabaseStudentEditor>();
		}

		[Test]
		public void AddStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentExtendedProxy { FirstName = "firstName" };

			RunServer(new AddStudentFunction(DatabaseAuthorizer, databaseStudentEditor));
			SendRequest("AddStudent", GetDefaultParameters(), student.ToJson());

			A.CallTo(() => databaseStudentEditor.Add(student)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteStudentFunctionTest_ShouldBeSuccess() {
			var student = new StudentBasedProxy { FirstName = "firstName" };

			RunServer(new DeleteStudentFunction(DatabaseAuthorizer, databaseStudentEditor));
			SendRequest("DeleteStudent", GetDefaultParameters(), student.ToJson());

			A.CallTo(() => databaseStudentEditor.Delete(student)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditStudentFunctionTest_ShouldBeSuccess() {
			var firstStudent = new StudentExtendedProxy { FirstName = "firstFirstName" };
			var secondStudent = new StudentExtendedProxy { FirstName = "secondFirstName" };

			RunServer(new EditStudentFunction(DatabaseAuthorizer, databaseStudentEditor));
			SendRequest("EditStudent", GetDefaultParameters(), Tuple.Create(firstStudent, secondStudent).ToJson());

			A.CallTo(() => databaseStudentEditor.Edit(firstStudent, secondStudent)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}