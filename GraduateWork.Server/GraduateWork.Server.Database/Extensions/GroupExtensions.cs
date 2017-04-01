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
			return new GroupBasedProxy {
				GroupName = group.GroupName
			};
		}

		public static GroupExtendedProxy[] ToExtendedProxies(this IEnumerable<Group> groups) {
			return groups.Select(group => group.ToExtendedProxy()).ToArray();
		}
		public static GroupExtendedProxy ToExtendedProxy(this Group group) {
			return new GroupExtendedProxy {
				GroupName = group.GroupName,
				SpecialtyName = group.SpecialtyName,
				SpecialtyNumber = group.SpecialtyNumber,
				FacultyName = group.FacultyName,
				Students = group.Students.ToBasedProxies(),
				Disciplines = group.Disciplines.ToBasedProxies()
			};
		}
	}
}