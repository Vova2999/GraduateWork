using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Edit {
	public class EditDisciplineFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditDiscipline";
		private readonly IDatabaseEditor databaseEditor;

		public EditDisciplineFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleDisciplines = requestBody.FromJson<Tuple<DisciplineProxy, DisciplineProxy>>();
			databaseEditor.EditDiscipline(tupleDisciplines.Item1, tupleDisciplines.Item2);
		}
	}
}