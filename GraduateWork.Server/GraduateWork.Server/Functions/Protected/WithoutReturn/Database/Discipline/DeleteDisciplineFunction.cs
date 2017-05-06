using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Discipline {
	public class DeleteDisciplineFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteDiscipline";
		protected override AccessType RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseDisciplineEditor databaseDisciplineEditor;

		public DeleteDisciplineFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseDisciplineEditor databaseDisciplineEditor) : base(databaseAuthorizer) {
			this.databaseDisciplineEditor = databaseDisciplineEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseDisciplineEditor.Delete(requestBody.FromJson<DisciplineBasedProxy>());
		}
	}
}