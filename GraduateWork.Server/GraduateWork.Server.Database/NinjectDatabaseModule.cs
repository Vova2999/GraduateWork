using System.Data.Entity;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Database.Models;
using Ninject.Modules;

namespace GraduateWork.Server.Database {
	public class NinjectDatabaseModule : NinjectModule {
		public override void Load() {
			System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelDatabase>());

			Kernel?.Bind<ModelDatabase>().To<ModelDatabase>().InSingletonScope();
			Kernel?.Bind<IDatabaseEditor>().To<DatabaseEditor>().InSingletonScope();
			Kernel?.Bind<IDatabaseReader>().To<DatabaseReader>().InSingletonScope();
			Kernel?.Bind<IDatabaseAuthorizer>().To<DatabaseAuthorizer>().InSingletonScope();
		}
	}
}