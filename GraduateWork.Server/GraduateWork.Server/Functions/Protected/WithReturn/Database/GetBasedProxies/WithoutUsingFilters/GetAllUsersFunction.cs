using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters {
	public class GetAllUsersFunction : HttpProtectedFunctionWithReturn<UserBasedProxy[]> {
		public override string NameOfCalledMethod => "GetAllUsers";
		protected override AccessType RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseReader databaseReader;

		public GetAllUsersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override UserBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllUsers();
		}
	}
}