using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn {
	public class AddStudentFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "/AddStudent";
		private readonly IModelDatabase modelDatabase;

		public AddStudentFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			modelDatabase.AddStudent(requestBody.FromJson<StudentProxy>());
		}
	}
}