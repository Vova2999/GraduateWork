using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Extensions {
	public static class GroupExtensions {
		public static GroupProxy[] ToProxies(this IEnumerable<Group> groups) {
			return groups.Select(group => group.ToProxy()).ToArray();
		}

		private static GroupProxy ToProxy(this Group group) {
			return new GroupProxy {
				NameOfGroup = group.NameOfGroup
			};
		}
	}
}