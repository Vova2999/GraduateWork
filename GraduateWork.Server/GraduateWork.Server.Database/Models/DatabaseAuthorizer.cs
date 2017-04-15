using System.Linq;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable UnusedMember.Global

	public class DatabaseAuthorizer : IDatabaseAuthorizer {
		private readonly ModelDatabase modelDatabase;

		public DatabaseAuthorizer(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;

			if (!modelDatabase.Users.Any())
				AddFirstUser();
		}
		private void AddFirstUser() {
			modelDatabase.Users.Add(new User {
				Login = "login",
				Password = "password",
				AccessType = int.MaxValue
			});
			modelDatabase.SaveChanges();
		}

		public bool UserIsExist(string login, string password) {
			return modelDatabase.Users.FirstOrDefault(user => user.Login == login && user.Password == password) != null;
		}
		public bool AccessIsAllowed(string login, string password, int requestedAccessType) {
			var foundUser = modelDatabase.Users.First(user => user.Login == login && user.Password == password);
			return -(foundUser.AccessType | -requestedAccessType - 1) - 1 == 0;
		}
	}
}