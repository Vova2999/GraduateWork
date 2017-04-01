using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Discipline {
	public class AddDisciplineFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddDiscipline";
		protected override AccessType RequiredAccessType => AccessType.UserEdit;
		private readonly IDatabaseEditor databaseEditor;

		public AddDisciplineFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.AddDiscipline(requestBody.FromJson<DisciplineExtendedProxy>());
		}
	}
}