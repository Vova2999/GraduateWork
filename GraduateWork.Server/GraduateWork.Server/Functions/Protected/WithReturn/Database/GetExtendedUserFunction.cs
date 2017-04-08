﻿using GraduateWork.Common;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetExtendedUserFunction : HttpProtectedFunctionWithReturn<UserExtendedProxy> {
		public override string NameOfCalledMethod => "GetExtendedUser";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetExtendedUserFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override UserExtendedProxy Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetExtendedUser(requestBody.FromJson<UserBasedProxy>());
		}
	}
}