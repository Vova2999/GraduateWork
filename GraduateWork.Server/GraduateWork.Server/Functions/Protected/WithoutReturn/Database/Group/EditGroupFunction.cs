using System;
using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Group {
	public class EditGroupFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditGroup";
		protected override AccessType RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseGroupEditor databaseGroupEditor;

		public EditGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseGroupEditor databaseGroupEditor) : base(databaseAuthorizer) {
			this.databaseGroupEditor = databaseGroupEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleGroups = requestBody.FromJson<Tuple<GroupExtendedProxy, GroupExtendedProxy>>();
			databaseGroupEditor.Edit(tupleGroups.Item1, tupleGroups.Item2);
		}
	}
}