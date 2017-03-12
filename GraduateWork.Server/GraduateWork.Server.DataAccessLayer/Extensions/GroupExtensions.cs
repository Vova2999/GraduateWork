using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer.Extensions {
	public static class GroupExtensions {
		public static IEnumerable<GroupProxy> ToProxies(this IEnumerable<Group> groups) {
			return groups.Select(group => group.ToProxy());
		}

		private static GroupProxy ToProxy(this Group group) {
			return new GroupProxy {
				NameOfGroup = group.NameOfGroup
			};
		}
	}
}