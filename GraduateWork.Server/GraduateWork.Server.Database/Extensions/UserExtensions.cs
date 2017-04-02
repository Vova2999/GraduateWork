using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Extensions {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedMember.Global

	public static class UserExtensions {
		public static UserProxy[] ToProxies(this IEnumerable<User> users) {
			return users.Select(user => user.ToProxy()).ToArray();
		}
		public static UserProxy ToProxy(this User user) {
			return new UserProxy {
				Login = user.Login,
				Password = user.Password,
				AccessType = user.AccessType
			};
		}
	}
}