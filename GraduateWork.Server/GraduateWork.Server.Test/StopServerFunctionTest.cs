using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using GraduateWork.Common.Http;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Functions;
using GraduateWork.Server.Functions.Protected.WithoutReturn;
using GraduateWork.Server.Server;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class StopServerFunctionTest : BaseHttpClient {
		[Test]
		public void StopServerFunctionTest_ShouldBeSuccess() {
			const string login = "login";
			const string password = "password";
			var parameters = new Dictionary<string, string> {
				{ HttpParameters.Login, login },
				{ HttpParameters.Password, password }
			};

			var databaseAuthorizer = A.Fake<IDatabaseAuthorizer>();
			A.CallTo(() => databaseAuthorizer.UserIsExist(login, password)).Returns(true);
			A.CallTo(() => databaseAuthorizer.AccessIsAllowed(login, password, A<int>.Ignored)).Returns(true);

			Task.Run(() => new HttpServer(new IHttpFunction[] { new StopServerFunction(databaseAuthorizer) }).Run());
			Thread.Sleep(100);

			SendRequest("Stop", parameters);
			Thread.Sleep(200);

			Assert.Catch(() => SendRequest("Stop", parameters));
		}
	}
}