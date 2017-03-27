using GraduateWork.Common.Extensions;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Reports;

namespace GraduateWork.Server.Functions.WithReturn.Reports {
	public class CreateDiplomaSupplementReportFunction : HttpFunctionWithReturn<FileWithContent> {
		public override string NameOfCalledMethod => "CreateDiplomaSupplementReport";
		private readonly IReportsCreator reportsCreator;

		public CreateDiplomaSupplementReportFunction(IReportsCreator reportsCreator) {
			this.reportsCreator = reportsCreator;
		}

		protected override FileWithContent Run(NameValues parameters, byte[] requestBody) {
			return reportsCreator.CreateDiplomaSupplement(requestBody.FromJson<StudentProxy>());
		}
	}
}