using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy {
	public class GetExtendedUserFunction : HttpProtectedFunctionWithReturn<UserExtendedProxy> {
		public override string NameOfCalledMethod => "GetExtendedUser";
		protected override AccessType RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetExtendedUserFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override UserExtendedProxy Run(NameValues parameters, byte[] requestBody) {
			return databaseUserReader.GetExtendedProxy(requestBody.FromJson<UserBasedProxy>());
		}
	}
}