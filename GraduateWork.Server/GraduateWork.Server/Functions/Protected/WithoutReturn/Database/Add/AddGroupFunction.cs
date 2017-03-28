﻿using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Add {
	public class AddGroupFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddGroup";
		protected override AccessType RequiredAccessType => AccessType.Edit;
		private readonly IDatabaseEditor databaseEditor;

		public AddGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.AddGroup(requestBody.FromJson<GroupProxy>());
		}
	}
}