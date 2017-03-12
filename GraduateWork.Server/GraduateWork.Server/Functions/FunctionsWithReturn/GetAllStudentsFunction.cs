using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllStudentsFunction : HttpFunctionWithReturn {
		public override string NameOfCalledMethod => "/GetAllStudents";
		private readonly IModelDatabase modelDatabase;

		public GetAllStudentsFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override byte[] Run(HttpListenerContext context, NameValues parameters) {
			return modelDatabase.Students.ToProxies().ToJson();
		}
	}
}