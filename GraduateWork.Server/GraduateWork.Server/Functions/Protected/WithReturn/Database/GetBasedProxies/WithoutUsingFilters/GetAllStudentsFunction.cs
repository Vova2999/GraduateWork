using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters {
	public class GetAllStudentsFunction : HttpProtectedFunctionWithReturn<StudentBasedProxy[]> {
		public override string NameOfCalledMethod => "GetAllStudents";
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseStudentReader databaseStudentReader;

		public GetAllStudentsFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseStudentReader databaseStudentReader) : base(databaseAuthorizer) {
			this.databaseStudentReader = databaseStudentReader;
		}

		protected override StudentBasedProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseStudentReader.GetAllBasedProies();
		}
	}
}