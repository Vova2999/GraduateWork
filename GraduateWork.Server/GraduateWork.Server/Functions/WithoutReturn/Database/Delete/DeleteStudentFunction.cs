using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Delete {
	public class DeleteStudentFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "DeleteStudent";
		private readonly IDatabaseEditor databaseEditor;

		public DeleteStudentFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.DeleteStudent(requestBody.FromJson<StudentProxy>());
		}
	}
}