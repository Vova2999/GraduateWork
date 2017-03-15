using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn {
	public class EditGroupFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "/EditGroup";
		private readonly IModelDatabase modelDatabase;

		public EditGroupFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleGroups = requestBody.FromJson<Tuple<GroupProxy, GroupProxy>>();
			modelDatabase.EditGroup(tupleGroups.Item1, tupleGroups.Item2);
		}
	}
}