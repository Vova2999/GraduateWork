using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllDisciplinesFunction : HttpFunctionWithReturn {
		public override string NameOfCalledMethod => "/GetAllDisciplines";
		private readonly IModelDatabase modelDatabase;

		public GetAllDisciplinesFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override byte[] Run(HttpListenerContext context, NameValues parameters) {
			return modelDatabase.Disciplines.ToProxies().ToJson();
		}
	}
}