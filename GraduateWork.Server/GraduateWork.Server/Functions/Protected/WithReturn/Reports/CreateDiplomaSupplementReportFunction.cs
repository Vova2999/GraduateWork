using GraduateWork.Common.Extensions;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Common.Reports;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Reports {
	public class CreateDiplomaSupplementReportFunction : HttpProtectedFunctionWithReturn<FileWithContent> {
		public override string NameOfCalledMethod => "CreateDiplomaSupplementReport";
		protected override AccessType RequiredAccessType => AccessType.Read;
		private readonly IReportsCreator reportsCreator;

		public CreateDiplomaSupplementReportFunction(IDatabaseAuthorizer databaseAuthorizer, IReportsCreator reportsCreator) : base(databaseAuthorizer) {
			this.reportsCreator = reportsCreator;
		}

		protected override FileWithContent Run(NameValues parameters, byte[] requestBody) {
			return reportsCreator.CreateDiplomaSupplement(requestBody.FromJson<StudentProxy>());
		}
	}
}