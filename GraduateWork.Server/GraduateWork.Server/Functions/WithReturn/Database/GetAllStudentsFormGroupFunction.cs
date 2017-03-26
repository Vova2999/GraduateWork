using System;
using System.Net;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;
using GraduateWork.Server.Exceptions;

namespace GraduateWork.Server.Functions.WithReturn.Database {
	public class GetAllStudentsFormGroupByNameFunction : HttpFunctionWithReturn<StudentProxy[]> {
		public override string NameOfCalledMethod => "GetAllStudentsFormGroupByName";
		private readonly IModelDatabase modelDatabase;

		public GetAllStudentsFormGroupByNameFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override StudentProxy[] Run(NameValues parameters, byte[] requestBody) {
			var nameOfGroup = parameters["NameOfGroup"];

			try {
				return modelDatabase.GetAllStudentsFormGroupByName(nameOfGroup);
			}
			catch (ArgumentException) {
				throw new HttpException(HttpStatusCode.NotFound, $"Группа '{nameOfGroup}' не найдена");
			}
		}
	}
}