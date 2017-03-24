using System;
using System.Net;
using FakeItEasy;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Exceptions;
using GraduateWork.Server.Functions;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpFunctionsThrowExceptionTest : HttpFunctionsTest {
		[Test]
		public void CalledFunctionDoesNotExist_ShouldBeThrowException() {
			RunServer();

			var exception = Assert.Catch<WebException>(() => SendRequest("notExistFunction"));
			Assert.That(((HttpWebResponse)exception.Response).StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
		}

		[Test]
		public void ThrowHttpExceptionTest_ShouldBeThrowException() {
			const string exceptionMessage = "message";
			const string nameOfCalledMethod = "nameOfCalledMethod";
			const HttpStatusCode exceptionStatusCode = HttpStatusCode.Forbidden;

			var function = A.Fake<IHttpFunction>();
			A.CallTo(() => function.NameOfCalledMethod).Returns(nameOfCalledMethod);
			A.CallTo(() => function.Execute(A<HttpListenerContext>.Ignored, A<NameValues>.Ignored, A<byte[]>.Ignored))
				.Throws(() => new HttpException(exceptionStatusCode, exceptionMessage));

			RunServer(function);

			var exception = Assert.Catch<WebException>(() => SendRequest(nameOfCalledMethod));
			Assert.That(((HttpWebResponse)exception.Response).StatusCode, Is.EqualTo(exceptionStatusCode));
			Assert.That(exception.Response.GetResponseStream().ReadAndDispose().FromJson<string>(), Is.EqualTo(exceptionMessage));
		}

		[Test]
		public void ThrowExceptionTest_ShouldBeThrowException() {
			const string exceptionMessage = "message";
			const string nameOfCalledMethod = "nameOfCalledMethod";

			var function = A.Fake<IHttpFunction>();
			A.CallTo(() => function.NameOfCalledMethod).Returns(nameOfCalledMethod);
			A.CallTo(() => function.Execute(A<HttpListenerContext>.Ignored, A<NameValues>.Ignored, A<byte[]>.Ignored))
				.Throws(() => new Exception(exceptionMessage));

			RunServer(function);

			var exception = Assert.Catch<WebException>(() => SendRequest(nameOfCalledMethod));
			Assert.That(((HttpWebResponse)exception.Response).StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
			Assert.That(exception.Response.GetResponseStream().ReadAndDispose().FromJson<string>(), Is.EqualTo(exceptionMessage));
		}
	}
}