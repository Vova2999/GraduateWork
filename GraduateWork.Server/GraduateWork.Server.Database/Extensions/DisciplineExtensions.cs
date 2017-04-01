using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Extensions {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedMember.Global

	public static class DisciplineExtensions {
		public static DisciplineBasedProxy[] ToBasedProxies(this IEnumerable<Discipline> disciplines) {
			return disciplines.Select(group => group.ToBasedProxy()).ToArray();
		}
		public static DisciplineBasedProxy ToBasedProxy(this Discipline discipline) {
			return new DisciplineBasedProxy {
				DisciplineName = discipline.DisciplineName,
				Group = discipline.Group.ToBasedProxy()
			};
		}

		public static DisciplineExtendedProxy[] ToExtendedProxies(this IEnumerable<Discipline> disciplines) {
			return disciplines.Select(group => group.ToExtendedProxy()).ToArray();
		}
		public static DisciplineExtendedProxy ToExtendedProxy(this Discipline discipline) {
			return new DisciplineExtendedProxy {
				DisciplineName = discipline.DisciplineName,
				ControlType = discipline.ControlType,
				TotalHours = discipline.TotalHours,
				ClassHours = discipline.ClassHours,
				Group = discipline.Group.ToBasedProxy()
			};
		}
	}
}