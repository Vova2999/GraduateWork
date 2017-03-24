using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Extensions;

namespace GraduateWork.Server.Functions {
	public abstract class HttpFunctionWithReturn<TKey> : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void Execute(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			var outputBytes = Run(parameters, requestBody).ToJson();
			context.Response.Respond(HttpStatusCode.OK, outputBytes);
		}

		protected abstract TKey Run(NameValues parameters, byte[] requestBody);
	}
}