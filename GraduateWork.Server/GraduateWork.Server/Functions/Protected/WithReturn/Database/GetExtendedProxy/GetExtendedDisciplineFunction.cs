using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy {
	public class GetExtendedDisciplineFunction : HttpProtectedFunctionWithReturn<DisciplineExtendedProxy> {
		public override string NameOfCalledMethod => "GetExtendedDiscipline";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseDisciplineReader databaseDisciplineReader;

		public GetExtendedDisciplineFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseDisciplineReader databaseDisciplineReader) : base(databaseAuthorizer) {
			this.databaseDisciplineReader = databaseDisciplineReader;
		}

		protected override DisciplineExtendedProxy Run(NameValues parameters, byte[] requestBody) {
			return databaseDisciplineReader.GetExtendedProxy(requestBody.FromJson<DisciplineBasedProxy>());
		}
	}
}