using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies {
	public class GetAllStudentsFunction : HttpProtectedFunctionWithReturn<StudentBasedProxy[]> {
		public override string NameOfCalledMethod => "GetAllStudents";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseReader databaseReader;

		public GetAllStudentsFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseReader databaseReader) : base(databaseAuthorizer) {
			this.databaseReader = databaseReader;
		}

		protected override StudentBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllStudents();
		}
	}
}