using System.Net;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Exceptions;

namespace GraduateWork.Server.Functions.Protected {
	public abstract class HttpProtectedFunction : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }
		protected abstract AccessType RequiredAccessType { get; }
		private readonly IDatabaseAuthorizer databaseAuthorizer;

		protected HttpProtectedFunction(IDatabaseAuthorizer databaseAuthorizer) {
			this.databaseAuthorizer = databaseAuthorizer;
		}

		public void Execute(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			if (parameters.NotContains(HttpParameters.Login) || parameters.NotContains(HttpParameters.Password))
				throw new HttpException(HttpStatusCode.Forbidden, "Для вызова этой функции необходимо передать параметры пользователя");
			if (!databaseAuthorizer.AccessIsAllowed(parameters[HttpParameters.Login], parameters[HttpParameters.Password], (int)RequiredAccessType))
				throw new HttpException(HttpStatusCode.Forbidden, "У вас нет доступа к этой функции");
			PerformRun(context, parameters, requestBody);
		}
		protected abstract void PerformRun(HttpListenerContext context, NameValues parameters, byte[] requestBody);
	}
}