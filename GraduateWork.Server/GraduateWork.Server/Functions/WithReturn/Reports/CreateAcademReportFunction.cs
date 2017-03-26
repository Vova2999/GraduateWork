using GraduateWork.Common.Extensions;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.WithReturn.Reports {
	public class CreateAcademReportFunction : HttpFunctionWithReturn<FileWithContent> {
		public override string NameOfCalledMethod => "CreateAcademReport";
		private readonly IReportsCreator reportsCreator;

		public CreateAcademReportFunction(IReportsCreator reportsCreator) {
			this.reportsCreator = reportsCreator;
		}

		protected override FileWithContent Run(NameValues parameters, byte[] requestBody) {
			return reportsCreator.CreateAcadem(requestBody.FromJson<StudentProxy>());
		}
	}
}