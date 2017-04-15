using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetDisciplineNamesFromGroupNameFunction : HttpProtectedFunctionWithReturn<string[]> {
		public override string NameOfCalledMethod => "GetDisciplineNamesFromGroupName";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetDisciplineNamesFromGroupNameFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override string[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetDisciplineNamesFromGroupName(parameters[HttpParameters.GroupName]);
		}
	}
}