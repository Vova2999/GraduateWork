using GraduateWork.Common;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database {
	public class GetExtendedStudentFunction : HttpProtectedFunctionWithReturn<StudentExtendedProxy> {
		public override string NameOfCalledMethod => "GetExtendedStudent";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetExtendedStudentFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override StudentExtendedProxy Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetExtendedStudent(requestBody.FromJson<StudentBasedProxy>());
		}
	}
}