using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy {
	public class GetExtendedGroupFunction : HttpProtectedFunctionWithReturn<GroupExtendedProxy> {
		public override string NameOfCalledMethod => "GetExtendedGroup";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseGroupReader databaseGroupReader;

		public GetExtendedGroupFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseGroupReader databaseGroupReader) : base(databaseAuthorizer) {
			this.databaseGroupReader = databaseGroupReader;
		}

		protected override GroupExtendedProxy Run(NameValues parameters, byte[] requestBody) {
			return databaseGroupReader.GetExtendedProxy(requestBody.FromJson<GroupBasedProxy>());
		}
	}
}