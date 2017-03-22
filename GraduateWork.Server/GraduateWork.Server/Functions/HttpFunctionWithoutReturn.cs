using System.Net;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions {
	public abstract class HttpFunctionWithoutReturn : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void Execute(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			Run(parameters, requestBody);

			context.Response.StatusCode = (int)HttpStatusCode.OK;
			context.Response.OutputStream.Dispose();
		}

		protected abstract void Run(NameValues parameters, byte[] requestBody);
	}
}