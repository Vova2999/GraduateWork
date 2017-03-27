using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithReturn.Database {
	public class GetAllStudentsFunction : HttpFunctionWithReturn<StudentProxy[]> {
		public override string NameOfCalledMethod => "GetAllStudents";
		private readonly IDatabaseReader databaseReader;

		public GetAllStudentsFunction(IDatabaseReader databaseReader) {
			this.databaseReader = databaseReader;
		}

		protected override StudentProxy[] Run(NameValues parameters, byte[] requestBody) {
			return databaseReader.GetAllStudents();
		}
	}
}