using System.Net;
using GraduateWork.Common.Database;
using GraduateWork.Common.Http;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Exceptions;

namespace GraduateWork.Server.Functions.NonProtected.WithoutReturn {
	public class CheckUserIsExistFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "CheckUserIsExist";
		private readonly IDatabaseAuthorizer databaseAuthorizer;

		public CheckUserIsExistFunction(IDatabaseAuthorizer databaseAuthorizer) {
			this.databaseAuthorizer = databaseAuthorizer;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			if (parameters.NotContains(HttpParameters.Login) || parameters.NotContains(HttpParameters.Password))
				throw new HttpException(HttpStatusCode.BadRequest, "Для вызова этой функции необходимо передать логин и пароль");
			if (!databaseAuthorizer.UserIsExist(parameters[HttpParameters.Login], parameters[HttpParameters.Password]))
				throw new HttpException(HttpStatusCode.NotFound, "Пользователь не найден");
		}
	}
}