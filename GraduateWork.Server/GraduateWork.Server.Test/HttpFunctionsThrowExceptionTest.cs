using System;
using System.Collections.Generic;
using System.Net;
using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Exceptions;
using GraduateWork.Server.Functions;
using GraduateWork.Server.Functions.NonProtected.WithoutReturn;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsThrowExceptionTest : BaseHttpServerTest {
		[Test]
		public void CalledFunctionDoesNotExist_ShouldBeThrowException() {
			RunServer();

			var exception = Assert.Catch<WebException>(() => SendRequest("notExistFunction", DefaultParameters));
			Assert.That(((HttpWebResponse)exception.Response).StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
		}

		[Test]
		public void ThrowHttpExceptionTest_ShouldBeThrowException() {
			const string exceptionMessage = "exceptionMessage";
			const string nameOfCalledMethod = "nameOfCalledMethod";
			const HttpStatusCode exceptionStatusCode = HttpStatusCode.Forbidden;

			var function = A.Fake<IHttpFunction>();
			A.CallTo(() => function.NameOfCalledMethod).Returns(nameOfCalledMethod);
			A.CallTo(() => function.Execute(A<HttpListenerContext>.Ignored, A<NameValues>.Ignored, A<byte[]>.Ignored))
				.Throws(() => new HttpException(exceptionStatusCode, exceptionMessage));

			RunServer(function);

			var exception = Assert.Catch<WebException>(() => SendRequest(nameOfCalledMethod, DefaultParameters));
			Assert.That(((HttpWebResponse)exception.Response).StatusCode, Is.EqualTo(exceptionStatusCode));
			Assert.That(exception.Response.GetResponseStream().ReadAndDispose().FromJson<string>(), Is.EqualTo(exceptionMessage));
		}

		[Test]
		public void ThrowExceptionTest_ShouldBeThrowException() {
			const string exceptionMessage = "exceptionMessage";
			const string nameOfCalledMethod = "nameOfCalledMethod";

			var function = A.Fake<IHttpFunction>();
			A.CallTo(() => function.NameOfCalledMethod).Returns(nameOfCalledMethod);
			A.CallTo(() => function.Execute(A<HttpListenerContext>.Ignored, A<NameValues>.Ignored, A<byte[]>.Ignored))
				.Throws(() => new Exception(exceptionMessage));

			RunServer(function);

			var exception = Assert.Catch<WebException>(() => SendRequest(nameOfCalledMethod, DefaultParameters));
			Assert.That(((HttpWebResponse)exception.Response).StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
			Assert.That(exception.Response.GetResponseStream().ReadAndDispose().FromJson<string>(), Is.EqualTo(exceptionMessage));
		}

		[Test]
		public void CheckUserIsCorrectFunctionTest_ShouldBeThrowException() {
			const string login = "login";
			const string password = "password";
			var parameters = new Dictionary<string, string> {
				{ HttpParameters.Login, login },
				{ HttpParameters.Password, password }
			};

			var databaseAuthorizer = A.Fake<IDatabaseAuthorizer>();
			A.CallTo(() => databaseAuthorizer.UserIsExist(login, password)).Returns(false);

			RunServer(new CheckUserIsExistFunction(databaseAuthorizer));
			var exception = Assert.Catch<WebException>(() => SendRequest("CheckUserIsExist", parameters));

			A.CallTo(() => databaseAuthorizer.UserIsExist(login, password)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(((HttpWebResponse)exception.Response).StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
		}
	}
}