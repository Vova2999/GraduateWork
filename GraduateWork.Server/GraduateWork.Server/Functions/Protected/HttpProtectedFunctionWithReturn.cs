using System.Net;
using GraduateWork.Common.Database;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Extensions;

namespace GraduateWork.Server.Functions.Protected {
	// ReSharper disable UnusedParameter.Global

	public abstract class HttpProtectedFunctionWithReturn<TResult> : HttpProtectedFunction {
		protected HttpProtectedFunctionWithReturn(IDatabaseAuthorizer databaseAuthorizer) : base(databaseAuthorizer) {
		}

		protected sealed override void PerformRun(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			var outputBytes = Run(parameters, requestBody).ToJson();
			context.Response.Respond(HttpStatusCode.OK, outputBytes);
		}
		protected abstract TResult Run(NameValues parameters, byte[] requestBody);
	}
}