using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Edit {
	public class EditDisciplineFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "/EditDiscipline";
		private readonly IModelDatabase modelDatabase;

		public EditDisciplineFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleDisciplines = requestBody.FromJson<Tuple<DisciplineProxy, DisciplineProxy>>();
			modelDatabase.EditDiscipline(tupleDisciplines.Item1, tupleDisciplines.Item2);
		}
	}
}