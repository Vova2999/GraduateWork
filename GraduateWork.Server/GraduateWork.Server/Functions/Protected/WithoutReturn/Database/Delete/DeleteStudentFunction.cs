using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Delete {
	public class DeleteStudentFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteStudent";
		protected override TypeAccess TypeAccess => TypeAccess.Edit;
		private readonly IDatabaseEditor databaseEditor;

		public DeleteStudentFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.DeleteStudent(requestBody.FromJson<StudentProxy>());
		}
	}
}