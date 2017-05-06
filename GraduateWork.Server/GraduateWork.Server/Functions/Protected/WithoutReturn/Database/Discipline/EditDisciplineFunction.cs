using System;
using GraduateWork.Common.Database;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Discipline {
	public class EditDisciplineFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => "EditDiscipline";
		protected override AccessType RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseDisciplineEditor databaseDisciplineEditor;

		public EditDisciplineFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseDisciplineEditor databaseDisciplineEditor) : base(databaseAuthorizer) {
			this.databaseDisciplineEditor = databaseDisciplineEditor;
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			var tupleDisciplines = requestBody.FromJson<Tuple<DisciplineExtendedProxy, DisciplineExtendedProxy>>();
			databaseDisciplineEditor.Edit(tupleDisciplines.Item1, tupleDisciplines.Item2);
		}
	}
}