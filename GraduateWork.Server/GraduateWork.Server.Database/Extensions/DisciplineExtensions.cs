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
			return ToProxy<DisciplineBasedProxy>(discipline);
		}

		public static DisciplineExtendedProxy[] ToExtendedProxies(this IEnumerable<Discipline> disciplines) {
			return disciplines.Select(group => group.ToExtendedProxy()).ToArray();
		}
		public static DisciplineExtendedProxy ToExtendedProxy(this Discipline discipline) {
			var disciplineProxy = ToProxy<DisciplineExtendedProxy>(discipline);
			disciplineProxy.ControlType = discipline.ControlType;
			disciplineProxy.TotalHours = discipline.TotalHours;
			disciplineProxy.ClassHours = discipline.ClassHours;

			return disciplineProxy;
		}

		private static TDisciplineProxy ToProxy<TDisciplineProxy>(Discipline discipline) where TDisciplineProxy : DisciplineBasedProxy, new() {
			return new TDisciplineProxy {
				DisciplineName = discipline.DisciplineName,
				GroupName = discipline.Group.GroupName
			};
		}
	}
}