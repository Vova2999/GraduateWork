using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetAllDisciplinesFunction : HttpProtectedFunctionWithReturn<DisciplineBasedProxy[]> {
		public override string NameOfCalledMethod => "GetAllDisciplines";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetAllDisciplinesFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override DisciplineBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllDisciplines();
		}
	}
}