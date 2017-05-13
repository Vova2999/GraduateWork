using System.Collections.Generic;
using FakeItEasy;
using GraduateWork.Common.Database;
using GraduateWork.Common.Http;
using GraduateWork.Server.Functions.NonProtected.WithoutReturn;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsWithoutUsingDatabaseTest : BaseHttpServerTest {
		[Test]
		public void PingFunctionTest_ShouldBeSuccess() {
			RunServer(new PingFunction());
			SendRequest("Ping");
		}

		[Test]
		public void CheckUserIsCorrectFunctionTest_ShouldBeSuccess() {
			const string login = "login";
			const string password = "password";
			var parameters = new Dictionary<string, string> {
				{ HttpParameters.Login, login },
				{ HttpParameters.Password, password }
			};

			var databaseAuthorizer = A.Fake<IDatabaseAuthorizer>();
			A.CallTo(() => databaseAuthorizer.UserIsExist(login, password)).Returns(true);

			RunServer(new CheckUserIsExistFunction(databaseAuthorizer));
			SendRequest("CheckUserIsExist", parameters);

			A.CallTo(() => databaseAuthorizer.UserIsExist(login, password)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}