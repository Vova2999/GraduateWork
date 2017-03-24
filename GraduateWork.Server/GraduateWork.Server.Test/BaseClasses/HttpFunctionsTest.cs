using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraduateWork.Server.Functions;
using GraduateWork.Server.Functions.FunctionsWithoutReturn;
using GraduateWork.Server.Server;
using NUnit.Framework;

namespace GraduateWork.Server.Test.BaseClasses {
	public class HttpFunctionsTest : BaseHttpClient {
		[TearDown]
		public void TearDown() {
			SendRequest("Stop");
			Thread.Sleep(200);
		}

		protected static void RunServer(params IHttpFunction[] functions) {
			Task.Run(() => new HttpServer(functions.Concat(new[] { new StopServerFunction() }).ToArray()).Run());
			Thread.Sleep(100);
		}
	}
}