using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Extensions;

namespace GraduateWork.Server.Functions {
	public abstract class HttpFunctionWithReturn<TKey> : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }

		public void Execute(HttpListenerContext context, NameValues parameters) {
			var outputBytes = Run(parameters).ToJson();

			context.Response.StatusCode = (int)HttpStatusCode.OK;
			context.Response.OutputStream.WriteAndDispose(outputBytes);
		}

		protected abstract TKey Run(NameValues parameters);
	}
}