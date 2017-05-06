using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseDisciplineReader : IDatabaseReader<DisciplineBasedProxy, DisciplineExtendedProxy> {
		DisciplineBasedProxy[] GetDisciplinesWithUsingFilters(string disciplineName, ControlType? controlType, string groupName);
	}
}