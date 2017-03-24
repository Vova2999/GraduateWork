using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllDisciplinesFunction : HttpFunctionWithReturn<DisciplineProxy[]> {
		public override string NameOfCalledMethod => "GetAllDisciplines";
		private readonly IModelDatabase modelDatabase;

		public GetAllDisciplinesFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override DisciplineProxy[] Run(NameValues parameters, byte[] requestBody) {
			return modelDatabase.GetAllDisciplines();
		}
	}
}