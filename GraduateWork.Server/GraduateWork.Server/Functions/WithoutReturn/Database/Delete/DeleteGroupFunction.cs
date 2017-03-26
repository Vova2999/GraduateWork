using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Delete {
	public class DeleteGroupFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteGroup";
		private readonly IModelDatabase modelDatabase;

		public DeleteGroupFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			modelDatabase.DeleteGroup(requestBody.FromJson<GroupProxy>());
		}
	}
}