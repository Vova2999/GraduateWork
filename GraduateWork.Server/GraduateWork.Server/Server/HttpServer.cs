using System;
using System.Linq;
using System.Net;
using GraduateWork.Server.Functions;

namespace GraduateWork.Server.Server {
	public class HttpServer : IHttpServer {
		private readonly IHttpFunction[] httpFunctions;

		public HttpServer(IHttpFunction[] httpFunctions) {
			this.httpFunctions = httpFunctions;
		}

		public void Run() {
			var httpListener = new HttpListener();
			httpListener.Prefixes.Add("http://127.0.0.1/");
			httpListener.Start();

			while (httpListener.IsListening) {
				var context = httpListener.GetContext();
				var function = httpFunctions.Single(f => string.Equals(f.NameOfCalledMethod, context.Request.RawUrl, StringComparison.InvariantCultureIgnoreCase));
				function.RunMethod(context);
			}
		}
	}
}