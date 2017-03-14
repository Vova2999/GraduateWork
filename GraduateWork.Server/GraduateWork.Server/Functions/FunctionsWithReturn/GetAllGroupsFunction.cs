using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllGroupsFunction : HttpFunctionWithReturn<GroupProxy[]> {
		public override string NameOfCalledMethod => "/GetAllGroups";
		private readonly IModelDatabase modelDatabase;

		public GetAllGroupsFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override GroupProxy[] Run(NameValues parameters) {
			return modelDatabase.Groups.ToProxies().ToArray();
		}
	}
}