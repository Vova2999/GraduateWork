using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters {
	public class GetStudentsWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<StudentBasedProxy[]> {
		public override string NameOfCalledMethod => "GetStudentsWithUsingFilters";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseStudentReader databaseStudentReader;

		public GetStudentsWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseStudentReader databaseStudentReader) : base(databaseAuthorizer) {
			this.databaseStudentReader = databaseStudentReader;
		}

		protected override StudentBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			var firstName = parameters.GetValueOrNull(HttpParameters.FirstName);
			var secondName = parameters.GetValueOrNull(HttpParameters.SecondName);
			var thirdName = parameters.GetValueOrNull(HttpParameters.ThirdName);
			var dateOfBirth = parameters.GetValueOrNull(HttpParameters.DateOfBirth)?.ToDateTime();

			return databaseStudentReader.GetStudentsWithUsingFilters(firstName, secondName, thirdName, dateOfBirth);
		}
	}
}