using System.Net;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Exceptions;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn {
	public class StopServerFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "Stop";
		protected override TypeAccess TypeAccess => TypeAccess.Read;

		public StopServerFunction(IDatabaseAuthorizer databaseAuthorizer) : base(databaseAuthorizer) {
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			throw new HttpStopServerException(HttpStatusCode.OK, "Работа сервера завершена");
		}
	}
}