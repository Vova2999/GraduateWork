using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Student {
	public class AddStudentFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddStudent";
		protected override AccessType RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseEditor databaseEditor;

		public AddStudentFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.AddStudent(requestBody.FromJson<StudentExtendedProxy>());
		}
	}
}