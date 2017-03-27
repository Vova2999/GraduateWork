using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetAllDisciplinesFunction : HttpProtectedFunctionWithReturn<DisciplineProxy[]> {
		public override string NameOfCalledMethod => "GetAllDisciplines";
		protected override TypeAccess TypeAccess => TypeAccess.Read;
		private readonly IDatabaseReader databaseReader;

		public GetAllDisciplinesFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override DisciplineProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllDisciplines();
		}
	}
}