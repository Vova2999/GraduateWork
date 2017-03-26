using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.WithoutReturn {
	public class PingFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "Ping";

		protected override void Run(NameValues parameters, byte[] requestBody) {
		}
	}
}