using GraduateWork.Common.Tables.Attributes;
using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Tables.Proxies.Extendeds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedMember.Global

	public class UserExtendedProxy : UserBasedProxy {
		[HeaderColumn("Пароль")]
		public string Password { get; set; }

		[HeaderColumn("Тип доступа")]
		public int AccessType { get; set; }

		public UserExtendedProxy GetExtendedClone() {
			var clone = GetClone<UserExtendedProxy>();
			clone.Password = Password;
			clone.AccessType = AccessType;

			return clone;
		}
	}
}