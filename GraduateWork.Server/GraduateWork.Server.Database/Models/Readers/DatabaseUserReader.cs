using System.Linq;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Extensions;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models.Readers {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseUserReader : DatabaseReader, IDatabaseUserReader {
		private readonly ModelDatabase modelDatabase;

		public DatabaseUserReader(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public UserBasedProxy[] GetAllBasedProies() {
			return modelDatabase.Users.ToBasedProxies();
		}
		public UserExtendedProxy GetExtendedProxy(UserBasedProxy basedProxy) {
			return modelDatabase.GetUser(basedProxy).ToExtendedProxy();
		}
		public UserBasedProxy[] GetUsersWithUsingFilters(string login) {
			IQueryable<User> users = modelDatabase.Users;
			UseFilter(login != null, ref users, user => user.Login.Contains(login));

			return users.ToBasedProxies();
		}
	}
}