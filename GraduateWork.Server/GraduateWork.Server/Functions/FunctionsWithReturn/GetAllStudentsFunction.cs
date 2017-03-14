using System.Collections.Generic;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllStudentsFunction : HttpFunctionWithReturn<IEnumerable<StudentProxy>> {
		public override string NameOfCalledMethod => "/GetAllStudents";
		private readonly IModelDatabase modelDatabase;

		public GetAllStudentsFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override IEnumerable<StudentProxy> Run(NameValues parameters) {
			return modelDatabase.Students.ToProxies();
		}
	}
}