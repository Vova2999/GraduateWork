using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Delete {
	public class DeleteGroupFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteGroup";
		private readonly IDatabaseEditor databaseEditor;

		public DeleteGroupFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.DeleteGroup(requestBody.FromJson<GroupProxy>());
		}
	}
}