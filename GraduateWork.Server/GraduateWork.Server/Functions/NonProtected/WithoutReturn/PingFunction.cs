using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.NonProtected.WithoutReturn {
	public class PingFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "Ping";

		protected override void Run(NameValues parameters, byte[] requestBody) {
		}
	}
}