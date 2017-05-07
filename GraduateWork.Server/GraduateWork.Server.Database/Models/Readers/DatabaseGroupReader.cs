using System.Linq;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Extensions;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models.Readers {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseGroupReader : DatabaseReader, IDatabaseGroupReader {
		private readonly ModelDatabase modelDatabase;

		public DatabaseGroupReader(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public GroupBasedProxy[] GetAllBasedProies() {
			return modelDatabase.Groups.ToBasedProxies();
		}
		public GroupExtendedProxy GetExtendedProxy(GroupBasedProxy basedProxy) {
			return modelDatabase.GetGroup(basedProxy).ToExtendedProxy();
		}
		public GroupBasedProxy[] GetGroupsWithUsingFilters(string groupName) {
			IQueryable<Group> groups = modelDatabase.Groups;
			UseFilter(groupName != null, ref groups, group => group.GroupName.Contains(groupName));

			return groups.ToBasedProxies();
		}
	}
}