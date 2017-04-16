using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.User {
	public class DeleteUserFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteUser";
		protected override AccessType RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseEditor databaseEditor;

		public DeleteUserFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.DeleteUser(requestBody.FromJson<UserBasedProxy>());
		}
	}
}