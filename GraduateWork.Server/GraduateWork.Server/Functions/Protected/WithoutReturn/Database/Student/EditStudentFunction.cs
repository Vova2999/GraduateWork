using System;
using GraduateWork.Common;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common.Database;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Student {
	public class EditStudentFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditStudent";
		protected override AccessType RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseEditor databaseEditor;

		public EditStudentFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseEditor databaseEditor) : base(databaseAuthorizer) {
			this.databaseEditor = databaseEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleStudents = requestBody.FromJson<Tuple<StudentExtendedProxy, StudentExtendedProxy>>();
			databaseEditor.EditStudent(tupleStudents.Item1, tupleStudents.Item2);
		}
	}
}