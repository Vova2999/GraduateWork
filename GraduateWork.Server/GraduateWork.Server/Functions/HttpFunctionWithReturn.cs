using System.Net;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions {
	public abstract class HttpFunctionWithReturn : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void Execute(HttpListenerContext context, NameValues parameters) {
			var outputBytes = Run(context, parameters);

			using (var stream = context.Response.OutputStream)
				stream.Write(outputBytes, 0, outputBytes?.Length ?? 0);
		}

		protected abstract byte[] Run(HttpListenerContext context, NameValues parameters);
	}
}