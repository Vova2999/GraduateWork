﻿using System;
using System.Linq;
using System.Net;
using GraduateWork.Common.Exceptions;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Functions;

namespace GraduateWork.Server.Server {
	public class HttpServer : IHttpServer {
		private readonly IHttpFunction[] httpFunctions;

		public HttpServer(IHttpFunction[] httpFunctions) {
			CheckInputFunctions(httpFunctions);
			this.httpFunctions = httpFunctions;
		}
		private void CheckInputFunctions(IHttpFunction[] httpFunctions) {
			var repeatedFunction = httpFunctions
				.GroupBy(function => function.NameOfCalledMethod)
				.FirstOrDefault(group => group.Count() != 1)?
				.First();

			if (repeatedFunction != null)
				throw new ArgumentException($"Обнаружены несколько функций с NameOfCalledMethod = {repeatedFunction.NameOfCalledMethod}");
		}

		public void Run() {
			var httpListener = new HttpListener();
			httpListener.Prefixes.Add("http://127.0.0.1/");
			httpListener.Start();

			while (httpListener.IsListening) {
				var context = httpListener.GetContext();

				try {
					var functionNameAndParameters = context.Request.RawUrl.Split('?');
					var functionName = functionNameAndParameters[0];
					var parameters = GetParameters(functionNameAndParameters);

					GetFunction(functionName).Execute(context, parameters);
				}
				catch (HttpException exception) {
					context.Response.StatusCode = (int)exception.StatusCode;
					context.Response.OutputStream.WriteAndDispose(exception.Message.ToJson());
				}
				catch (Exception exception) {
					context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
					context.Response.OutputStream.WriteAndDispose(exception.Message.ToJson());
				}
			}
		}
		private NameValues GetParameters(string[] functionNameAndParameters) {
			if (functionNameAndParameters.Length > 2)
				throw new HttpException(HttpStatusCode.BadRequest, "В запросе не может быть несколько знаков '?'");

			return functionNameAndParameters.Length > 1
				? GetParameters(functionNameAndParameters[1])
				: new NameValues();
		}
		private NameValues GetParameters(string parameters) {
			try {
				return new NameValues(parameters.Split('&')
					.Select(parameter => parameter.Split('='))
					.Where(keyValue => keyValue.Length > 1)
					.ToDictionary(keyValue => keyValue[0], keyValue => keyValue[1]));
			}
			catch (Exception) {
				throw new HttpException(HttpStatusCode.BadRequest, "Неверные прарметры функции");
			}
		}
		private IHttpFunction GetFunction(string functionName) {
			var function = httpFunctions
				.FirstOrDefault(f => string.Equals(f.NameOfCalledMethod, functionName, StringComparison.InvariantCultureIgnoreCase));

			if (function == null)
				throw new HttpException(HttpStatusCode.NotFound, $"Функция '{functionName}' не найдена");

			return function;
		}
	}
}