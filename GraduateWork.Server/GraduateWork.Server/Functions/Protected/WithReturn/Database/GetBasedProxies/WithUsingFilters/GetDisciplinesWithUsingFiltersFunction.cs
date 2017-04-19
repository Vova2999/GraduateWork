using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters {
	public class GetDisciplinesWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<DisciplineBasedProxy[]> {
		public override string NameOfCalledMethod => "GetDisciplinesWithUsingFilters";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetDisciplinesWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override DisciplineBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			var disciplineName = parameters.GetValueOrNull(HttpParameters.DisciplineName);
			var controlType = parameters.GetValueOrNull(HttpParameters.ControlType)?.ToEnum<ControlType>();
			var groupName = parameters.GetValueOrNull(HttpParameters.GroupName);

			return databaseReader.GetDisciplinesWithUsingFilters(disciplineName, controlType, groupName);
		}
	}
}