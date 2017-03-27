using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Edit {
	public class EditDisciplineFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditDiscipline";
		protected override TypeAccess TypeAccess => TypeAccess.Edit;
		private readonly IDatabaseEditor databaseEditor;

		public EditDisciplineFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleDisciplines = requestBody.FromJson<Tuple<DisciplineProxy, DisciplineProxy>>();
			databaseEditor.EditDiscipline(tupleDisciplines.Item1, tupleDisciplines.Item2);
		}
	}
}