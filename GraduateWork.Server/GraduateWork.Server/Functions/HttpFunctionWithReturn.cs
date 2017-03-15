using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions {
	public abstract class HttpFunctionWithReturn<TKey> : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void Execute(HttpListenerContext context, NameValues parameters) {
			var requestBody = context.Request.InputStream.ReadAndDispose();
			var outputBytes = Run(parameters, requestBody).ToJson();

			context.Response.StatusCode = (int)HttpStatusCode.OK;
			context.Response.OutputStream.WriteAndDispose(outputBytes);
		}

		protected abstract TKey Run(NameValues parameters, byte[] requestBody);
	}
}