using System.Net;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn {
	public class PingFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "/Ping";

		protected override void Run(HttpListenerContext context, NameValues parameters) {
			context.Response.StatusCode = (int)HttpStatusCode.OK;
		}
	}
}