using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseUserReader : IDatabaseReader<UserBasedProxy, UserExtendedProxy> {
		UserBasedProxy[] GetUsersWithUsingFilters(string login);
	}
}