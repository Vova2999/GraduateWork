using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters {
	public class GetAllDisciplinesFunction : HttpProtectedFunctionWithReturn<DisciplineBasedProxy[]> {
		public override string NameOfCalledMethod => "GetAllDisciplines";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseDisciplineReader databaseDisciplineReader;

		public GetAllDisciplinesFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseDisciplineReader databaseDisciplineReader) : base(databaseAuthorizer) {
			this.databaseDisciplineReader = databaseDisciplineReader;
		}

		protected override DisciplineBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseDisciplineReader.GetAllBasedProies();
		}
	}
}