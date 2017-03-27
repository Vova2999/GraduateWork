using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Edit {
	public class EditGroupFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditGroup";
		private readonly IDatabaseEditor databaseEditor;

		public EditGroupFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleGroups = requestBody.FromJson<Tuple<GroupProxy, GroupProxy>>();
			databaseEditor.EditGroup(tupleGroups.Item1, tupleGroups.Item2);
		}
	}
}