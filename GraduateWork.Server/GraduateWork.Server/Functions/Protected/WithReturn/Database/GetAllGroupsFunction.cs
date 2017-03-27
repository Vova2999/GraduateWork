using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetAllGroupsFunction : HttpProtectedFunctionWithReturn<GroupProxy[]> {
		public override string NameOfCalledMethod => "GetAllGroups";
		protected override TypeAccess TypeAccess => TypeAccess.Read;
		private readonly IDatabaseReader databaseReader;

		public GetAllGroupsFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override GroupProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllGroups();
		}
	}
}