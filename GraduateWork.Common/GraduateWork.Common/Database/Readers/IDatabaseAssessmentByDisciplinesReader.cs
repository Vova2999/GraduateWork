using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseAssessmentByDisciplinesReader {
		AssessmentByDiscipline[] GetAssessmentByDisciplinesFromGroupName(string groupName);
	}
}