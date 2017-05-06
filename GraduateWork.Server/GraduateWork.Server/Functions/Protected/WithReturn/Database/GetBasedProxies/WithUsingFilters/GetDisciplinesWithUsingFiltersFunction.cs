using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters {
	public class GetDisciplinesWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<DisciplineBasedProxy[]> {
		public override string NameOfCalledMethod => "GetDisciplinesWithUsingFilters";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseDisciplineReader databaseDisciplineReader;

		public GetDisciplinesWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseDisciplineReader databaseDisciplineReader) : base(databaseAuthorizer) {
			this.databaseDisciplineReader = databaseDisciplineReader;
		}

		protected override DisciplineBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			var disciplineName = parameters.GetValueOrNull(HttpParameters.DisciplineName);
			var controlType = parameters.GetValueOrNull(HttpParameters.ControlType)?.ToEnum<ControlType>();
			var groupName = parameters.GetValueOrNull(HttpParameters.GroupName);

			return databaseDisciplineReader.GetDisciplinesWithUsingFilters(disciplineName, controlType, groupName);
		}
	}
}