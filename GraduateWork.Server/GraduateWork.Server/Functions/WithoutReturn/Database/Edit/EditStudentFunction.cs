using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.WithoutReturn.Database.Edit {
	public class EditStudentFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditStudent";
		private readonly IDatabaseEditor databaseEditor;

		public EditStudentFunction(IDatabaseEditor databaseEditor) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleStudents = requestBody.FromJson<Tuple<StudentProxy, StudentProxy>>();
			databaseEditor.EditStudent(tupleStudents.Item1, tupleStudents.Item2);
		}
	}
}