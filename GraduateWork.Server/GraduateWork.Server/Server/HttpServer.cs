using System;
using System.Linq;
using System.Net;
using GraduateWork.Server.AdditionalObjects;
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
				var functionNameAndParameters = context.Request.RawUrl.Split('?');
				var functionName = functionNameAndParameters[0];
				var parameters = functionNameAndParameters.Length > 1
					? GetParameters(functionNameAndParameters[1])
					: new NameValues();

				var function = httpFunctions.Single(f => string.Equals(f.NameOfCalledMethod, functionName, StringComparison.InvariantCultureIgnoreCase));

				function.Execute(context, parameters);
			}
		}
		private NameValues GetParameters(string parameters) {
			return new NameValues(parameters.Split('&')
				.Select(parameter => parameter.Split('='))
				.ToDictionary(keyValue => keyValue[0], keyValue => keyValue[1]));
		}
	}
}