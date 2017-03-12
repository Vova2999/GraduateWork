using System.Linq;
using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllStudentsFormGroupFunction : HttpFunctionWithReturn {
		public override string NameOfCalledMethod => "/GetAllStudentsFormGroup";
		private readonly IModelDatabase modelDatabase;

		public GetAllStudentsFormGroupFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override byte[] Run(HttpListenerContext context, NameValues parameters) {
			var nameOfGroup = parameters["NameOfGroup"];

			return modelDatabase.Groups.FirstOrDefault(group => group.NameOfGroup == nameOfGroup)?.Students.ToProxies().ToJson();
		}
	}
}