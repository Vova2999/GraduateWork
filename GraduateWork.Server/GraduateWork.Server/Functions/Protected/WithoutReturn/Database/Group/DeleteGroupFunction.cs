using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Group {
	public class DeleteGroupFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteGroup";
		protected override AccessType RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseGroupEditor databaseGroupEditor;

		public DeleteGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseGroupEditor databaseGroupEditor) : base(databaseAuthorizer) {
			this.databaseGroupEditor = databaseGroupEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseGroupEditor.Delete(requestBody.FromJson<GroupBasedProxy>());
		}
	}
}