using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Add {
	public class AddDisciplineFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddDiscipline";
		private readonly IDatabaseEditor databaseEditor;

		public AddDisciplineFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.AddDiscipline(requestBody.FromJson<DisciplineProxy>());
		}
	}
}