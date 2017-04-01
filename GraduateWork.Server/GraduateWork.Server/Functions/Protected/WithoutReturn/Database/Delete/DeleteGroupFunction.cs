﻿using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Delete {
	public class DeleteGroupFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteGroup";
		protected override AccessType RequiredAccessType => AccessType.Edit;
		private readonly IDatabaseEditor databaseEditor;

		public DeleteGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.DeleteGroup(requestBody.FromJson<GroupProxy>());
		}
	}
}