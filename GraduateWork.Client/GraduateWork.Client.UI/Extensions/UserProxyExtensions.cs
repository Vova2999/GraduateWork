using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.Extensions {
	public static class UserProxyExtensions {
		public static bool IsHaveAccess(this UserExtendedProxy user, AccessType accessType) {
			return (user.AccessType & (int)accessType) != 0;
		}
		public static void AddAccess(this UserExtendedProxy user, AccessType accessType) {
			user.AccessType |= (int)accessType;
		}
	}
}