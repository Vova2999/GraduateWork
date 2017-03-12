using System.Net;
using GraduateWork.Common.Extensions;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllDisciplinesFunction : HttpFunctionWithReturn {
		public override string NameOfCalledMethod => "/GetAllDisciplines";
		private readonly ModelDatabase modelDatabase;

		public GetAllDisciplinesFunction(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override byte[] Run(HttpListenerContext context) {
			return modelDatabase.Disciplines.ToProxies().ToJson();
		}
	}
}