using System;
using GraduateWork.Common;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Group {
	public class EditGroupFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditGroup";
		protected override AccessType RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseEditor databaseEditor;

		public EditGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleGroups = requestBody.FromJson<Tuple<GroupExtendedProxy, GroupExtendedProxy>>();
			databaseEditor.EditGroup(tupleGroups.Item1, tupleGroups.Item2);
		}
	}
}