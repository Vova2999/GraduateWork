using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Add {
	public class AddGroupFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddGroup";
		private readonly IDatabaseEditor databaseEditor;

		public AddGroupFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.AddGroup(requestBody.FromJson<GroupProxy>());
		}
	}
}