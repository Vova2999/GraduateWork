using System.Net;

namespace GraduateWork.Server.Functions {
	public abstract class HttpFunctionWithReturn : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void RunMethod(HttpListenerContext context) {
			var outputBytes = Run(context);

			using (var stream = context.Response.OutputStream)
				stream.Write(outputBytes, 0, outputBytes.Length);
		}

		protected abstract byte[] Run(HttpListenerContext context);
	}
}