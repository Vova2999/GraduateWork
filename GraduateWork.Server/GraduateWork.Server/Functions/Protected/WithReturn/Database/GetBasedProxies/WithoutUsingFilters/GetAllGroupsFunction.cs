using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters {
	public class GetAllGroupsFunction : HttpProtectedFunctionWithReturn<GroupBasedProxy[]> {
		public override string NameOfCalledMethod => "GetAllGroups";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseGroupReader databaseGroupReader;

		public GetAllGroupsFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseGroupReader databaseGroupReader) : base(databaseAuthorizer) {
			this.databaseGroupReader = databaseGroupReader;
		}

		protected override GroupBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseGroupReader.GetAllBasedProies();
		}
	}
}