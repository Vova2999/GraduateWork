using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Delete {
	public class DeleteDisciplineFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteDiscipline";
		private readonly IDatabaseEditor databaseEditor;

		public DeleteDisciplineFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.DeleteDiscipline(requestBody.FromJson<DisciplineProxy>());
		}
	}
}