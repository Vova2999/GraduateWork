using System.Collections.Generic;
using FakeItEasy;
using GraduateWork.Common.Database;
using GraduateWork.Common.Http;
using NUnit.Framework;

namespace GraduateWork.Server.Test.BaseClasses {
	public abstract class BaseHttpServerWithUsingDatabaseAuthorizerTest : BaseHttpServerTest {
		private const string login = "login";
		private const string password = "password";
		protected IDatabaseAuthorizer DatabaseAuthorizer;

		[SetUp]
		public void BaseHttpServerWithUsingDatabaseAuthorizerTest_SetUp() {
			DatabaseAuthorizer = A.Fake<IDatabaseAuthorizer>();
			A.CallTo(() => DatabaseAuthorizer.UserIsExist(login, password)).Returns(true);
			A.CallTo(() => DatabaseAuthorizer.AccessIsAllowed(login, password, A<int>.Ignored)).Returns(true);
		}

		[TearDown]
		public void BaseHttpServerWithUsingDatabaseAuthorizerTest_TearDown() {
			A.CallTo(() => DatabaseAuthorizer.AccessIsAllowed(login, password, A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
		}

		protected static Dictionary<string, string> GetDefaultParameters() {
			return new Dictionary<string, string> {
				[HttpParameters.Login] = login,
				[HttpParameters.Password] = password
			};
		}
	}
}