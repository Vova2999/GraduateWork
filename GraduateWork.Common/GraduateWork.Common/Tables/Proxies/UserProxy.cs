using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	// ReSharper disable UnusedMember.Global

	public class UserProxy {
		[HeaderColumn("Логин")]
		public string Login { get; set; }

		[HeaderColumn("Пароль")]
		public string Password { get; set; }

		[HeaderColumn("Тип доступа")]
		public int AccessType { get; set; }

		public override bool Equals(object obj) {
			var that = (UserProxy)obj;
			return that != null && Login == that.Login && Password == that.Password;
		}
		public override int GetHashCode() {
			unchecked {
				return ((Login?.GetHashCode() ?? 0) * 397) ^ (Password?.GetHashCode() ?? 0);
			}
		}
	}

	public enum AccessType {
		None = 0x00,
		Read = 0x01,
		Edit = 0x02
	}
}