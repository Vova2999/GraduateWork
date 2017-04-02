using System.Net;
using GraduateWork.Common.Http;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Exceptions;

namespace GraduateWork.Server.Functions.NonProtected.WithoutReturn {
	public class CheckUserIsExistFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "CheckUserIsExist";
		private readonly IDatabaseAuthorizer databaseAuthorizer;

		public CheckUserIsExistFunction(IDatabaseAuthorizer databaseAuthorizer) {
			this.databaseAuthorizer = databaseAuthorizer;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			if (!databaseAuthorizer.UserIsExist(parameters[HttpParameters.Login], parameters[HttpParameters.Password]))
				throw new HttpException(HttpStatusCode.NotFound, "Пользователь не найден");
		}
	}
}