using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithReturn.Database {
	public class GetAllGroupsFunction : HttpFunctionWithReturn<GroupProxy[]> {
		public override string NameOfCalledMethod => "GetAllGroups";
		private readonly IDatabaseReader databaseReader;

		public GetAllGroupsFunction(IDatabaseReader databaseReader) {
			this.databaseReader = databaseReader;
		}

		protected override GroupProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllGroups();
		}
	}
}