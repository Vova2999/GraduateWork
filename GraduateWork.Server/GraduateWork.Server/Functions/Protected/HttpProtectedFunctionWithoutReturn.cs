using System.Net;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Extensions;

namespace GraduateWork.Server.Functions.Protected {
	// ReSharper disable UnusedParameter.Global

	public abstract class HttpProtectedFunctionWithoutReturn : HttpProtectedFunction {
		protected HttpProtectedFunctionWithoutReturn(IDatabaseAuthorizer databaseAuthorizer) : base(databaseAuthorizer) {
		}

		protected sealed override void PerformRun(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			Run(parameters, requestBody);
			context.Response.Respond(HttpStatusCode.OK, null);
		}
		protected abstract void Run(NameValues parameters, byte[] requestBody);
	}
}