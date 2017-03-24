using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.AdditionalObjects;
using GraduateWork.Server.Common;

namespace GraduateWork.Server.Functions.FunctionsWithoutReturn.DatabaseEditing.Add {
	public class AddDisciplineFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => "AddDiscipline";
		private readonly IModelDatabase modelDatabase;

		public AddDisciplineFunction(IModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			modelDatabase.AddDiscipline(requestBody.FromJson<DisciplineProxy>());
		}
	}
}