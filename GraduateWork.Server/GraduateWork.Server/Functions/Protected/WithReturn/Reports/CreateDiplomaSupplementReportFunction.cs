using GraduateWork.Common.Database;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Reports {
	public class CreateDiplomaSupplementReportFunction : HttpProtectedFunctionWithReturn<FileWithContent> {
		public override string NameOfCalledMethod => "CreateDiplomaSupplementReport";
		protected override AccessType RequiredAccessType => AccessType.CreateReport;
		private readonly IReportsCreator reportsCreator;

		public CreateDiplomaSupplementReportFunction(IDatabaseAuthorizer databaseAuthorizer, IReportsCreator reportsCreator) : base(databaseAuthorizer) {
			this.reportsCreator = reportsCreator;
		}

		protected override FileWithContent Run(NameValues parameters, byte[] requestBody) {
			return reportsCreator.CreateDiplomaSupplement(requestBody.FromJson<StudentExtendedProxy>());
		}
	}
}