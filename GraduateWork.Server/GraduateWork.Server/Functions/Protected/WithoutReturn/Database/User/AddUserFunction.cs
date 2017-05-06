using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.User {
	public class AddUserFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddUser";
		protected override AccessType RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseUserEditor databaseUserEditor;

		public AddUserFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserEditor databaseUserEditor) : base(databaseAuthorizer) {
			this.databaseUserEditor = databaseUserEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseUserEditor.Add(requestBody.FromJson<UserExtendedProxy>());
		}
	}
}