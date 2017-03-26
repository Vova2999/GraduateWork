using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common;
using GraduateWork.Server.Functions.WithReturn.Reports;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsWithUsingReportCreatorTest : HttpFunctionsTest {
		private IReportsCreator reportsCreator;

		[SetUp]
		public void SetUp() {
			reportsCreator = A.Fake<IReportsCreator>();
		}

		[Test]
		public void CreateAcademReportFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };
			var fileWithContent = new FileWithContent("TestName", null);
			A.CallTo(() => reportsCreator.CreateAcadem(student)).Returns(fileWithContent);

			RunServer(new CreateAcademReportFunction(reportsCreator));
			var receivedFileWithContent = SendRequest<FileWithContent>("CreateAcademReport", student.ToJson());

			A.CallTo(() => reportsCreator.CreateAcadem(student)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedFileWithContent.FileName, Is.EqualTo(fileWithContent.FileName));
		}

		[Test]
		public void CreateDiplomaReportFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };
			var fileWithContent = new FileWithContent("TestName", null);
			A.CallTo(() => reportsCreator.CreateDiploma(student)).Returns(fileWithContent);

			RunServer(new CreateDiplomaReportFunction(reportsCreator));
			var receivedFileWithContent = SendRequest<FileWithContent>("CreateDiplomaReport", student.ToJson());

			A.CallTo(() => reportsCreator.CreateDiploma(student)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedFileWithContent.FileName, Is.EqualTo(fileWithContent.FileName));
		}

		[Test]
		public void CreateDiplomaSupplementReportFunctionTest_ShouldBeSuccess() {
			var student = new StudentProxy { FirstName = "firstName" };
			var fileWithContent = new FileWithContent("TestName", null);
			A.CallTo(() => reportsCreator.CreateDiplomaSupplement(student)).Returns(fileWithContent);

			RunServer(new CreateDiplomaSupplementReportFunction(reportsCreator));
			var receivedFileWithContent = SendRequest<FileWithContent>("CreateDiplomaSupplementReport", student.ToJson());

			A.CallTo(() => reportsCreator.CreateDiplomaSupplement(student)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedFileWithContent.FileName, Is.EqualTo(fileWithContent.FileName));
		}
	}
}