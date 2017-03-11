using System.Net;

namespace GraduateWork.Server.Functions {
	public abstract class HttpFunctionWithoutReturn : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void RunMethod(HttpListenerContext context) {
			Run(context);

			context.Response.OutputStream.Dispose();
		}

		protected abstract void Run(HttpListenerContext context);
	}
}