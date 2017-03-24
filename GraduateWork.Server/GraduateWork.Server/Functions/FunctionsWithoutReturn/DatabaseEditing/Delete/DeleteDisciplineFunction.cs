﻿using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Delete {
	public class DeleteDisciplineFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteDiscipline";
		private readonly IModelDatabase modelDatabase;

		public DeleteDisciplineFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			modelDatabase.DeleteDiscipline(requestBody.FromJson<DisciplineProxy>());
		}
	}
}