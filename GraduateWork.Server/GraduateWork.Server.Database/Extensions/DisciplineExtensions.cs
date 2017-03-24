using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Extensions {
	public static class DisciplineExtensions {
		public static DisciplineProxy[] ToProxies(this IEnumerable<Discipline> disciplines) {
			return disciplines.Select(group => group.ToProxy()).ToArray();
		}

		private static DisciplineProxy ToProxy(this Discipline discipline) {
			return new DisciplineProxy {
				NameOfDiscipline = discipline.NameOfDiscipline
			};
		}
	}
}