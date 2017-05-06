using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Student {
	public class DeleteStudentFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteStudent";
		protected override AccessType RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseStudentEditor databaseStudentEditor;

		public DeleteStudentFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseStudentEditor databaseStudentEditor) : base(databaseAuthorizer) {
			this.databaseStudentEditor = databaseStudentEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseStudentEditor.Delete(requestBody.FromJson<StudentBasedProxy>());
		}
	}
}