using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllGroupsFunction : HttpFunctionWithReturn {
		public override string NameOfCalledMethod => "/GetAllGroups";
		private readonly ModelDatabase modelDatabase;

		public GetAllGroupsFunction(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override byte[] Run(HttpListenerContext context) {
			return modelDatabase.Groups.ToProxies().ToJson();
		}
	}
}