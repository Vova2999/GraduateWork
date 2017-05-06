using System.Linq;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Extensions;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models.Readers {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseDisciplineReader : DatabaseReader, IDatabaseDisciplineReader {
		private readonly ModelDatabase modelDatabase;

		public DatabaseDisciplineReader(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public DisciplineBasedProxy[] GetAllBasedProies() {
			return modelDatabase.Disciplines.ToBasedProxies();
		}
		public DisciplineExtendedProxy GetExtendedProxy(DisciplineBasedProxy basedProxy) {
			return modelDatabase.GetDiscipline(basedProxy).ToExtendedProxy();
		}
		public DisciplineBasedProxy[] GetDisciplinesWithUsingFilters(string disciplineName, ControlType? controlType, string groupName) {
			IQueryable<Discipline> disciplines = modelDatabase.Disciplines;
			UseFilter(disciplineName != null, ref disciplines, discipline => discipline.DisciplineName.Contains(disciplineName));
			UseFilter(controlType != null, ref disciplines, discipline => discipline.ControlType == controlType);
			UseFilter(groupName != null, ref disciplines, discipline => discipline.Group.GroupName.Contains(groupName));

			return disciplines.ToBasedProxies();
		}
	}
}