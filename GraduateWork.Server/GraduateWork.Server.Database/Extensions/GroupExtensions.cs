using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Extensions {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedMember.Global

	public static class GroupExtensions {
		public static GroupBasedProxy[] ToBasedProxies(this IEnumerable<Group> groups) {
			return groups.Select(group => group.ToBasedProxy()).ToArray();
		}
		public static GroupBasedProxy ToBasedProxy(this Group group) {
			return ToProxy<GroupBasedProxy>(group);
		}

		public static GroupExtendedProxy[] ToExtendedProxies(this IEnumerable<Group> groups) {
			return groups.Select(group => group.ToExtendedProxy()).ToArray();
		}
		public static GroupExtendedProxy ToExtendedProxy(this Group group) {
			var groupProxy = ToProxy<GroupExtendedProxy>(group);
			groupProxy.Students = group.Students.ToBasedProxies();
			groupProxy.Disciplines = group.Disciplines.ToBasedProxies();

			return groupProxy;
		}

		private static TGroupProxy ToProxy<TGroupProxy>(Group group) where TGroupProxy : GroupBasedProxy, new() {
			return new TGroupProxy {
				GroupName = group.GroupName,
				SpecialtyName = group.SpecialtyName,
				SpecialtyNumber = group.SpecialtyNumber,
				FacultyName = group.FacultyName
			};
		}
	}
}