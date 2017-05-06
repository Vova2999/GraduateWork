using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Group {
	public class AddGroupFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddGroup";
		protected override AccessType RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseGroupEditor databaseGroupEditor;

		public AddGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseGroupEditor databaseGroupEditor) : base(databaseAuthorizer) {
			this.databaseGroupEditor = databaseGroupEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseGroupEditor.Add(requestBody.FromJson<GroupExtendedProxy>());
		}
	}
}