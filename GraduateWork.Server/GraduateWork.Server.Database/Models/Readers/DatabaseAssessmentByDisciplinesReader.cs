using System.Linq;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Server.Database.Models.Readers {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseAssessmentByDisciplinesReader : DatabaseReader, IDatabaseAssessmentByDisciplinesReader {
		private readonly ModelDatabase modelDatabase;

		public DatabaseAssessmentByDisciplinesReader(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public AssessmentByDiscipline[] GetAssessmentByDisciplinesFromGroupName(string groupName) {
			return modelDatabase.GetGroup(groupName)
				.Disciplines.Select(
					discipline => new AssessmentByDiscipline {
						NameOfDiscipline = discipline.DisciplineName,
						ControlType = discipline.ControlType,
						Assessment = Assessment.None
					})
				.ToArray();
		}
	}
}