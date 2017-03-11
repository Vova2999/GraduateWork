using System.Collections.Generic;
using System.Linq;
using GraduateWork.Server.DataAccessLayer.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer.Extensions {
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