using System.Net;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions {
	public abstract class HttpFunctionWithoutReturn : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void Execute(HttpListenerContext context, NameValues parameters) {
			Run(parameters);

			context.Response.StatusCode = (int)HttpStatusCode.OK;
			context.Response.OutputStream.Dispose();
		}

		protected abstract void Run(NameValues parameters);
	}
}