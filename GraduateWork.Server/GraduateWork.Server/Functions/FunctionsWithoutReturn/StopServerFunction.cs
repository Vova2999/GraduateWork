using System.Net;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Exceptions;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn {
	public class StopServerFunction : IHttpFunction {
		public string NameOfCalledMethod => "Stop";

		public void Execute(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			throw new HttpStopServerException(HttpStatusCode.OK, "Работа сервера завершена");
		}
	}
}