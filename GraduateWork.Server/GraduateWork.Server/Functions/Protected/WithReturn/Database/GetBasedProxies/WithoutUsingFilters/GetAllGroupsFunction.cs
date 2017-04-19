using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters {
	public class GetAllGroupsFunction : HttpProtectedFunctionWithReturn<GroupBasedProxy[]> {
		public override string NameOfCalledMethod => "GetAllGroups";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetAllGroupsFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override GroupBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllGroups();
		}
	}
}