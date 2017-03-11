using System.Net;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllStudentsFunction : HttpFunctionWithReturn {
		public override string NameOfCalledMethod => "/GetAllStudents";

		protected override byte[] Run(HttpListenerContext context) {
			throw new System.NotImplementedException();
		}
	}
}