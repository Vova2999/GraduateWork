using System.Linq;
using System.Net;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;
using GraduateWork.Server.Exceptions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllStudentsFormGroupByNameFunction : HttpFunctionWithReturn<StudentProxy[]> {
		public override string NameOfCalledMethod => "GetAllStudentsFormGroupByName";
		private readonly IModelDatabase modelDatabase;

		public GetAllStudentsFormGroupByNameFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override StudentProxy[] Run(NameValues parameters, byte[] requestBody) {
			var nameOfGroup = parameters["NameOfGroup"];

			var group = modelDatabase.Groups.FirstOrDefault(g => g.NameOfGroup == nameOfGroup);
			if (group == null)
				throw new HttpException(HttpStatusCode.NotFound, $"Группа '{nameOfGroup}' не найдена");

			return group.Students.ToProxies().ToArray();
		}
	}
}