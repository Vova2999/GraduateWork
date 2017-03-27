using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Add {
	public class AddDisciplineFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddDiscipline";
		protected override TypeAccess TypeAccess => TypeAccess.Edit;
		private readonly IDatabaseEditor databaseEditor;

		public AddDisciplineFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.AddDiscipline(requestBody.FromJson<DisciplineProxy>());
		}
	}
}