using GraduateWork.Server.Functions;

namespace GraduateWork.Server.Server {
	public class HttpServer : IHttpServer {
		private readonly IHttpFunction[] httpFunctions;

		public HttpServer(IHttpFunction[] httpFunctions) {
			this.httpFunctions = httpFunctions;
		}

		public void Run() {
			while (true) { }
		}
	}
}