using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetAssessmentByDisciplinesFromGroupNameFunction : HttpProtectedFunctionWithReturn<AssessmentByDiscipline[]> {
		public override string NameOfCalledMethod => "GetAssessmentByDisciplinesFromGroupName";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetAssessmentByDisciplinesFromGroupNameFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override AssessmentByDiscipline[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAssessmentByDisciplinesFromGroupName(parameters[HttpParameters.GroupName]);
		}
	}
}