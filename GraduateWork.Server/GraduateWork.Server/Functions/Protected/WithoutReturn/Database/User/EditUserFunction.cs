using System;
using GraduateWork.Common;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.User {
	public class EditUserFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditUser";
		protected override AccessType RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseEditor databaseEditor;

		public EditUserFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleUsers = requestBody.FromJson<Tuple<UserExtendedProxy, UserExtendedProxy>>();
			databaseEditor.EditUser(tupleUsers.Item1, tupleUsers.Item2);
		}
	}
}