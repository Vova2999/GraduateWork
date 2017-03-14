using System.Collections.Generic;
using System.Linq;
using System.Net;
using GraduateWork.Common.Exceptions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllStudentsFormGroupFunction : HttpFunctionWithReturn<IEnumerable<StudentProxy>> {
		public override string NameOfCalledMethod => "/GetAllStudentsFormGroup";
		private readonly IModelDatabase modelDatabase;

		public GetAllStudentsFormGroupFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override IEnumerable<StudentProxy> Run(NameValues parameters) {
			var nameOfGroup = parameters["NameOfGroup"];

			var group = modelDatabase.Groups.FirstOrDefault(g => g.NameOfGroup == nameOfGroup);
			if (group == null)
				throw new HttpException(HttpStatusCode.NotFound, $"Группа '{nameOfGroup}' не найдена");

			return group.Students.ToProxies();
		}
	}
}