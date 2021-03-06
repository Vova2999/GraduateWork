using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters {
	public class GetGroupsWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<GroupBasedProxy[]> {
		public override string NameOfCalledMethod => "GetGroupsWithUsingFilters";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseGroupReader databaseGroupReader;

		public GetGroupsWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseGroupReader databaseGroupReader) : base(databaseAuthorizer) {
			this.databaseGroupReader = databaseGroupReader;
		}

		protected override GroupBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			var groupName = parameters.GetValueOrNull(HttpParameters.GroupName);

			return databaseGroupReader.GetGroupsWithUsingFilters(groupName);
		}
	}
}