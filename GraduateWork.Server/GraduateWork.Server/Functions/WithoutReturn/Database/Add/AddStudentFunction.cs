using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Add {
	public class AddStudentFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddStudent";
		private readonly IDatabaseEditor databaseEditor;

		public AddStudentFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			databaseEditor.AddStudent(requestBody.FromJson<StudentProxy>());
		}
	}
}