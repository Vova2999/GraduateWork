using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Student {
	public class AddStudentFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddStudent";
		protected override AccessType RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseStudentEditor databaseStudentEditor;

		public AddStudentFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseStudentEditor databaseStudentEditor) : base(databaseAuthorizer) {
			this.databaseStudentEditor = databaseStudentEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseStudentEditor.Add(requestBody.FromJson<StudentExtendedProxy>());
		}
	}
}