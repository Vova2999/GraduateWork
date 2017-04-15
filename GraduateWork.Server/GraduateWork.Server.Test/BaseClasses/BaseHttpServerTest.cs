using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Exceptions;
using GraduateWork.Server.Functions;
using GraduateWork.Server.Server;
using NUnit.Framework;

namespace GraduateWork.Server.Test.BaseClasses {
	public class BaseHttpServerTest : BaseHttpClient {
		private const string nameOfCalledStopFunction = "Stop";

		[TearDown]
		public void BaseHttpServerTest_TearDown() {
			SendRequest(nameOfCalledStopFunction);
			Thread.Sleep(200);
		}

		protected void RunServer(params IHttpFunction[] functions) {
			Task.Run(() => new HttpServer(functions.Concat(new[] { CreateStopServerFunction() }).ToArray()).Run("http://127.0.0.1/"));
			Thread.Sleep(100);
		}
		private IHttpFunction CreateStopServerFunction() {
			var stopServerFunction = A.Fake<IHttpFunction>();
			A.CallTo(() => stopServerFunction.NameOfCalledMethod).Returns(nameOfCalledStopFunction);
			A.CallTo(() => stopServerFunction.Execute(A<HttpListenerContext>.Ignored, A<NameValues>.Ignored, A<byte[]>.Ignored))
				.Throws(() => new HttpStopServerException(HttpStatusCode.OK, string.Empty));

			return stopServerFunction;
		}
	}
}