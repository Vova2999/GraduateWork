using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllStudentsFunction : HttpFunctionWithReturn<StudentProxy[]> {
		public override string NameOfCalledMethod => "GetAllStudents";
		private readonly IModelDatabase modelDatabase;

		public GetAllStudentsFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override StudentProxy[] Run(NameValues parameters, byte[] requestBody) {
			return modelDatabase.GetAllStudents();
		}
	}
}