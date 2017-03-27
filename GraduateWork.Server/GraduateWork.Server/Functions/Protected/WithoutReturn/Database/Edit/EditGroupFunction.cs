using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Edit {
	public class EditGroupFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditGroup";
		protected override TypeAccess TypeAccess => TypeAccess.Edit;
		private readonly IDatabaseEditor databaseEditor;

		public EditGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleGroups = requestBody.FromJson<Tuple<GroupProxy, GroupProxy>>();
			databaseEditor.EditGroup(tupleGroups.Item1, tupleGroups.Item2);
		}
	}
}