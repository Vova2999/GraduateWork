using System.Collections.Generic;
using System.Linq;
using GraduateWork.Server.DataAccessLayer.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer.Extensions {
	public static class DisciplineExtensions {
		public static DisciplineProxy[] ToProxies(this IEnumerable<Discipline> disciplines) {
			return disciplines.Select(group => group.ToProxy()).ToArray();
		}

		private static DisciplineProxy ToProxy(this Discipline discipline) {
			return new DisciplineProxy() {
				NameOfDiscipline = discipline.NameOfDiscipline
			};
		}
	}
}