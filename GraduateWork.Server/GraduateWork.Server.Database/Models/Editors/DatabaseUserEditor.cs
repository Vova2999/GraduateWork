using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models.Editors {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseUserEditor : DatabaseEditor, IDatabaseUserEditor {
		public DatabaseUserEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(UserExtendedProxy extendedProxy) {
			ModelDatabase.Users.Add(new User {
				Login = extendedProxy.Login,
				Password = extendedProxy.Password,
				AccessType = extendedProxy.AccessType
			});

			ModelDatabase.SaveChanges();
		}
		public void Edit(UserExtendedProxy oldExtendedProxy, UserExtendedProxy newExtendedProxy) {
			var foundUser = ModelDatabase.GetUser(oldExtendedProxy);

			foundUser.Login = newExtendedProxy.Login;
			foundUser.Password = newExtendedProxy.Password;
			foundUser.AccessType = newExtendedProxy.AccessType;

			ModelDatabase.SaveChanges();
		}
		public void Delete(UserBasedProxy basedProxy) {
			var foundUser = ModelDatabase.GetUser(basedProxy);
			ModelDatabase.Users.Remove(foundUser);
			ModelDatabase.SaveChanges();
		}
	}
}