using System.Data.Entity;
using GraduateWork.Server.Database.Models;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace GraduateWork.Server.Database {
	public class NinjectDatabaseModule : NinjectModule {
		public override void Load() {
			System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelDatabase>());

			Kernel?.Bind<ModelDatabase>().ToSelf().InSingletonScope();
			Kernel?.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
		}
	}
}