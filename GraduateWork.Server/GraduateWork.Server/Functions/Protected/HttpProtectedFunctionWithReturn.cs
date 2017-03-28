using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Extensions;

namespace GraduateWork.Server.Functions.Protected {
	public abstract class HttpProtectedFunctionWithReturn<TKey> : HttpProtectedFunction {
		protected HttpProtectedFunctionWithReturn(IDatabaseAuthorizer databaseAuthorizer) : base(databaseAuthorizer) {
		}

		protected sealed override void PerformRun(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			var outputBytes = Run(parameters, requestBody).ToJson();
			context.Response.Respond(HttpStatusCode.OK, outputBytes);
		}
		protected abstract TKey Run(NameValues parameters, byte[] requestBody);
	}
}