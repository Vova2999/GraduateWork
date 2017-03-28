using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Add {
	public class AddUserFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddUser";
		protected override AccessType RequiredAccessType => AccessType.Edit;
		private readonly IDatabaseEditor databaseEditor;

		public AddUserFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.AddUser(requestBody.FromJson<UserProxy>());
		}
	}
}