using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy {
	public class GetExtendedStudentFunction : HttpProtectedFunctionWithReturn<StudentExtendedProxy> {
		public override string NameOfCalledMethod => "GetExtendedStudent";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseStudentReader databaseStudentReader;

		public GetExtendedStudentFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseStudentReader databaseStudentReader) : base(databaseAuthorizer) {
			this.databaseStudentReader = databaseStudentReader;
		}

		protected override StudentExtendedProxy Run(NameValues parameters, byte[] requestBody) {
			return databaseStudentReader.GetExtendedProxy(requestBody.FromJson<StudentBasedProxy>());
		}
	}
}