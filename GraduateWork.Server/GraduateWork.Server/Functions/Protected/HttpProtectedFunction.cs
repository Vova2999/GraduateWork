﻿using System.Net;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Exceptions;

namespace GraduateWork.Server.Functions.Protected {
	public abstract class HttpProtectedFunction : IHttpFunction {
		public abstract string NameOfCalledMethod { get; }
		protected abstract TypeAccess TypeAccess { get; }
		private readonly IDatabaseAuthorizer databaseAuthorizer;

		protected HttpProtectedFunction(IDatabaseAuthorizer databaseAuthorizer) {
			this.databaseAuthorizer = databaseAuthorizer;
		}

		public void Execute(HttpListenerContext context, NameValues parameters, byte[] requestBody) {
			if (!databaseAuthorizer.AccessIsAllowed(parameters[HttpParameters.Login], parameters[HttpParameters.Password], (int)TypeAccess))
				throw new HttpException(HttpStatusCode.Forbidden, "У вас нет доступа к этой функции");
			PerformRun(context, parameters, requestBody);
		}
		protected abstract void PerformRun(HttpListenerContext context, NameValues parameters, byte[] requestBody);
	}
}