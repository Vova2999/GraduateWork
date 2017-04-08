using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Extensions {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedMember.Global

	public static class UserExtensions {
		public static UserBasedProxy[] ToBasedProxies(this IEnumerable<User> users) {
			return users.Select(user => user.ToBasedProxy()).ToArray();
		}
		public static UserBasedProxy ToBasedProxy(this User user) {
			return ToProxy<UserBasedProxy>(user);
		}

		public static UserExtendedProxy[] ToExtendedProxies(this IEnumerable<User> users) {
			return users.Select(user => user.ToExtendedProxy()).ToArray();
		}
		public static UserExtendedProxy ToExtendedProxy(this User user) {
			var userProxy = ToProxy<UserExtendedProxy>(user);
			userProxy.AccessType = user.AccessType;

			return userProxy;
		}

		private static TUserProxy ToProxy<TUserProxy>(User user) where TUserProxy : UserBasedProxy, new() {
			return new TUserProxy {
				Login = user.Login,
				Password = user.Password
			};
		}
	}
}