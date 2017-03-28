using System.Net;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Extensions;

namespace GraduateWork.Server.Functions.NonProtected {
	public abstract class HttpFunctionWithoutReturn : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void Execute(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			Run(parameters, requestBody);
			context.Response.Respond(HttpStatusCode.OK, null);
		}
		protected abstract void Run(NameValues parameters, byte[] requestBody);
	}
}