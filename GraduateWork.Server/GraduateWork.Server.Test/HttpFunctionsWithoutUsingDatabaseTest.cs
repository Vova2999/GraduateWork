﻿using System.Collections.Generic;
using FakeItEasy;
using GraduateWork.Common.Http;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Functions.NonProtected.WithoutReturn;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
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
			A.CallTo(() => databaseAuthorizer.UserIsCorrect(login, password)).Returns(true);

			RunServer(new CheckUserIsCorrectFunction(databaseAuthorizer));
			SendRequest("CheckUserIsCorrect", parameters);

			A.CallTo(() => databaseAuthorizer.UserIsCorrect(login, password)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}