using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetAllUsersFunction : HttpProtectedFunctionWithReturn<UserProxy[]> {
		public override string NameOfCalledMethod => "GetAllUsers";
		protected override AccessType RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseReader databaseReader;

		public GetAllUsersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override UserProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllUsers();
		}
	}
}