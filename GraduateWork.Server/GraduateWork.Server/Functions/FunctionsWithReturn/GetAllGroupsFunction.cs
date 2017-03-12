using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllGroupsFunction : HttpFunctionWithReturn {
		public override string NameOfCalledMethod => "/GetAllGroups";
		private readonly IModelDatabase modelDatabase;

		public GetAllGroupsFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override byte[] Run(HttpListenerContext context, NameValues parameters) {
			return modelDatabase.Groups.ToProxies().ToJson();
		}
	}
}