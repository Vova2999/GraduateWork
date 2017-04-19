using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters {
	public class GetUsersWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<UserBasedProxy[]> {
		public override string NameOfCalledMethod => "GetUsersWithUsingFilters";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetUsersWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override UserBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			var login = parameters.GetValueOrNull(HttpParameters.LoginForFilter);

			return databaseReader.GetUsersWithUsingFilters(login);
		}
	}
}