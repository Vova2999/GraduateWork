using GraduateWork.Common;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Discipline {
	public class DeleteDisciplineFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteDiscipline";
		protected override AccessType RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseEditor databaseEditor;

		public DeleteDisciplineFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.DeleteDiscipline(requestBody.FromJson<DisciplineExtendedProxy>());
		}
	}
}