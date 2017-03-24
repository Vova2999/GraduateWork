using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllGroupsFunction : HttpFunctionWithReturn<GroupProxy[]> {
		public override string NameOfCalledMethod => "GetAllGroups";
		private readonly IModelDatabase modelDatabase;

		public GetAllGroupsFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override GroupProxy[] Run(NameValues parameters, byte[] requestBody) {
			return modelDatabase.GetAllGroups();
		}
	}
}