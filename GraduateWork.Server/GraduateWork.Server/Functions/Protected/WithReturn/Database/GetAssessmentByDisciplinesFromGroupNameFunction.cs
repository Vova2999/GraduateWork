using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetAssessmentByDisciplinesFromGroupNameFunction : HttpProtectedFunctionWithReturn<AssessmentByDiscipline[]> {
		public override string NameOfCalledMethod => "GetAssessmentByDisciplinesFromGroupName";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseAssessmentByDisciplinesReader databaseAssessmentByDisciplinesReader;

		public GetAssessmentByDisciplinesFromGroupNameFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseAssessmentByDisciplinesReader databaseAssessmentByDisciplinesReader) : base(databaseAuthorizer) {
			this.databaseAssessmentByDisciplinesReader = databaseAssessmentByDisciplinesReader;
		}

		protected override AssessmentByDiscipline[] Run(NameValues parameters, byte[] requestBody) {
			return databaseAssessmentByDisciplinesReader.GetAssessmentByDisciplinesFromGroupName(parameters[HttpParameters.GroupName]);
		}
	}
}