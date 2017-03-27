using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Edit {
	public class EditStudentFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditStudent";
		protected override TypeAccess TypeAccess => TypeAccess.Edit;
		private readonly IDatabaseEditor databaseEditor;

		public EditStudentFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleStudents = requestBody.FromJson<Tuple<StudentProxy, StudentProxy>>();
			databaseEditor.EditStudent(tupleStudents.Item1, tupleStudents.Item2);
		}
	}
}