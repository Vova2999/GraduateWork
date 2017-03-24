using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Delete {
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