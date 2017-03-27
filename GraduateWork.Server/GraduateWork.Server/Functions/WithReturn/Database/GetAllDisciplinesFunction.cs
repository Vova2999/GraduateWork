using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithReturn.Database {
	public class GetAllDisciplinesFunction : HttpFunctionWithReturn<DisciplineProxy[]> {
		public override string NameOfCalledMethod => "GetAllDisciplines";
		private readonly IDatabaseReader databaseReader;

		public GetAllDisciplinesFunction(IDatabaseReader databaseReader) {
			this.databaseReader = databaseReader;
		}

		protected override DisciplineProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllDisciplines();
		}
	}
}