using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters {
	public class GetUsersWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<UserBasedProxy[]> {
		public override string NameOfCalledMethod => "GetUsersWithUsingFilters";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetUsersWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override UserBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			var login = parameters.GetValueOrNull(HttpParameters.LoginForFilter);

			return databaseUserReader.GetUsersWithUsingFilters(login);
		}
	}
}