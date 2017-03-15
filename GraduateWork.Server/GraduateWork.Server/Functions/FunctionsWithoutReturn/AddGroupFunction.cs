using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn {
	public class AddGroupFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "/AddGroup";
		private readonly IModelDatabase modelDatabase;

		public AddGroupFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			modelDatabase.AddGroup(requestBody.FromJson<GroupProxy>());
		}
	}
}