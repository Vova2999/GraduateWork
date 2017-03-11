using System.Net;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;
using GraduateWork.Server.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllStudentsFunction : HttpFunctionWithReturn {
		public override string NameOfCalledMethod => "/GetAllStudents";
		private readonly ModelDatabase modelDatabase;

		public GetAllStudentsFunction(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override byte[] Run(HttpListenerContext context) {
			return modelDatabase.Students.ToProxies().ToJson();
		}
	}
}