using GraduateWork.Common.Database;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Database.Models;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn {
	// ReSharper disable UnusedMember.Global

	public class LoadTestDataFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "LoadTestData";
		protected override AccessType RequiredAccessType => AccessType.AdminWrite;
		private readonly TestDataLoader testDataLoader;

		public LoadTestDataFunction(IDatabaseAuthorizer databaseAuthorizer, TestDataLoader testDataLoader) : base(databaseAuthorizer) {
			this.testDataLoader = testDataLoader;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			testDataLoader.Load();
		}
	}
}