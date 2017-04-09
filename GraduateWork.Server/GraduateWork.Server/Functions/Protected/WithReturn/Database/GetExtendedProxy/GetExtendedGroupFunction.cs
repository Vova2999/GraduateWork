using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy {
	public class GetExtendedGroupFunction : HttpProtectedFunctionWithReturn<GroupExtendedProxy> {
		public override string NameOfCalledMethod => "GetExtendedGroup";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetExtendedGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override GroupExtendedProxy Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetExtendedGroup(requestBody.FromJson<GroupBasedProxy>());
		}
	}
}