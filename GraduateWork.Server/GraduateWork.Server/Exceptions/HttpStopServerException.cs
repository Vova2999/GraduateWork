using System.Net;

namespace GraduateWork.Server.Exceptions {
	public class HttpStopServerException : HttpException {
		public HttpStopServerException(HttpStatusCode statusCode, string message) : base(statusCode, message) {
		}
	}
}