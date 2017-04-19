using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters {
	public class GetGroupsWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<GroupBasedProxy[]> {
		public override string NameOfCalledMethod => "GetGroupsWithUsingFilters";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetGroupsWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override GroupBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			var groupName = parameters.GetValueOrNull(HttpParameters.GroupName);
			var specialtyNumber = parameters.GetValueOrNull(HttpParameters.SpecialtyNumber).ToInt();
			var specialtyName = parameters.GetValueOrNull(HttpParameters.SpecialtyName);
			var facultyName = parameters.GetValueOrNull(HttpParameters.FacultyName);

			return databaseReader.GetGroupsWithUsingFilters(groupName, specialtyNumber, specialtyName, facultyName);
		}
	}
}