using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer.Extensions {
	public static class DisciplineExtensions {
		public static IEnumerable<DisciplineProxy> ToProxies(this IEnumerable<Discipline> disciplines) {
			return disciplines.Select(group => group.ToProxy());
		}

		private static DisciplineProxy ToProxy(this Discipline discipline) {
			return new DisciplineProxy {
				NameOfDiscipline = discipline.NameOfDiscipline
			};
		}
	}
}