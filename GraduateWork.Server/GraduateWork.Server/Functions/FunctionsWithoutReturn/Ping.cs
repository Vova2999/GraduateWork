using System.Net;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn {
	public class Ping : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "/Ping";

		protected override void Run(HttpListenerContext context) {
			context.Response.StatusCode = (int)HttpStatusCode.OK;
		}
	}
}