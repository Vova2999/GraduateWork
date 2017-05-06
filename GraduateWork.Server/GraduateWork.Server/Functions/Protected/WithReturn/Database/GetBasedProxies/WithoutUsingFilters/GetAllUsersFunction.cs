using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters {
	public class GetAllUsersFunction : HttpProtectedFunctionWithReturn<UserBasedProxy[]> {
		public override string NameOfCalledMethod => "GetAllUsers";
		protected override AccessType RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetAllUsersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override UserBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseUserReader.GetAllBasedProies();
		}
	}
}