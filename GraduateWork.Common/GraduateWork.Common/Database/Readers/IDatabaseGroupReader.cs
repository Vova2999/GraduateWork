using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseGroupReader : IDatabaseReader<GroupBasedProxy, GroupExtendedProxy> {
		GroupBasedProxy[] GetGroupsWithUsingFilters(string groupName, int? specialtyNumber, string specialtyName, string facultyName);
	}
}