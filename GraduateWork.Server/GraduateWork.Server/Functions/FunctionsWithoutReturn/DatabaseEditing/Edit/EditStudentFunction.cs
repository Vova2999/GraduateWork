using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Edit {
	public class EditStudentFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditStudent";
		private readonly IModelDatabase modelDatabase;

		public EditStudentFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleStudents = requestBody.FromJson<Tuple<StudentProxy, StudentProxy>>();
			modelDatabase.EditStudent(tupleStudents.Item1, tupleStudents.Item2);
		}
	}
}