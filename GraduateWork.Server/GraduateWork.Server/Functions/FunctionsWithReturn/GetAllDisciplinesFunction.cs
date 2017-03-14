using System.Collections.Generic;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.DataAccessLayer.Extensions;

namespace GraduateWork.Server.Functions.FunctionsWithReturn {
	public class GetAllDisciplinesFunction : HttpFunctionWithReturn<IEnumerable<DisciplineProxy>> {
		public override string NameOfCalledMethod => "/GetAllDisciplines";
		private readonly IModelDatabase modelDatabase;

		public GetAllDisciplinesFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override IEnumerable<DisciplineProxy> Run(NameValues parameters) {
			return modelDatabase.Disciplines.ToProxies();
		}
	}
}