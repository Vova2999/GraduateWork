using System;
using FakeItEasy;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test.HttpFunctionsWithUsingDatabaseReaderTests {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseStudentReaderTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseStudentReader databaseStudentReader;

		[SetUp]
		public void SetUp() {
			databaseStudentReader = A.Fake<IDatabaseStudentReader>();
		}

		[Test]
		public void GetAllStudentsFunctionTest_ShouldBeSuccess() {
			var inputStudents = new[] {
				new StudentBasedProxy { FirstName = "firstFirstName" },
				new StudentBasedProxy { FirstName = "secondFirstName" }
			};
			A.CallTo(() => databaseStudentReader.GetAllBasedProies()).Returns(inputStudents);

			RunServer(new GetAllStudentsFunction(DatabaseAuthorizer, databaseStudentReader));
			var receivedStudents = SendRequest<StudentExtendedProxy[]>("GetAllStudents", GetDefaultParameters());

			A.CallTo(() => databaseStudentReader.GetAllBasedProies()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputStudents, receivedStudents);
		}

		[Test]
		public void GetStudentsWithUsingFiltersFunctionTest_ShouldBeSuccess() {
			var firstName = "firstName";
			var secondName = "secondName";
			var thirdName = "thirdName";
			var dateOfBirth = new DateTime(2000, 1, 1);
			var inputStudents = new[] {
				new StudentBasedProxy { FirstName = "firstFirstName" },
				new StudentBasedProxy { FirstName = "secondFirstName" }
			};
			A.CallTo(() => databaseStudentReader.GetStudentsWithUsingFilters(firstName, secondName, thirdName, dateOfBirth)).Returns(inputStudents);

			RunServer(new GetStudentsWithUsingFiltersFunction(DatabaseAuthorizer, databaseStudentReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.FirstName] = firstName;
			parameters[HttpParameters.SecondName] = secondName;
			parameters[HttpParameters.ThirdName] = thirdName;
			parameters[HttpParameters.DateOfBirth] = dateOfBirth.ToShortDateString();
			var receivedStudents = SendRequest<StudentExtendedProxy[]>("GetStudentsWithUsingFilters", parameters);

			A.CallTo(() => databaseStudentReader.GetStudentsWithUsingFilters(firstName, secondName, thirdName, dateOfBirth)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputStudents, receivedStudents);
		}

		[Test]
		public void GetExtendedStudentFunctionTest_ShouldBeSuccess() {
			var inputBasedStudent = new StudentBasedProxy { FirstName = "firstName" };
			var inputExtendedStudent = new StudentExtendedProxy { FirstName = "firstName" };
			A.CallTo(() => databaseStudentReader.GetExtendedProxy(inputBasedStudent)).Returns(inputExtendedStudent);

			RunServer(new GetExtendedStudentFunction(DatabaseAuthorizer, databaseStudentReader));
			var receivedStudent = SendRequest<StudentExtendedProxy>("GetExtendedStudent", GetDefaultParameters(), inputBasedStudent.ToJson());

			A.CallTo(() => databaseStudentReader.GetExtendedProxy(inputBasedStudent)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedStudent, Is.EqualTo(inputExtendedStudent));
		}
	}
}