using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Delete {
	public class DeleteStudentFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteStudent";
		private readonly IModelDatabase modelDatabase;

		public DeleteStudentFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			modelDatabase.DeleteStudent(requestBody.FromJson<StudentProxy>());
		}
	}
}