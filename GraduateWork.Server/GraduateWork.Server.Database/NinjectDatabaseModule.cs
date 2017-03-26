using GraduateWork.Server.Common;
using Ninject.Modules;

namespace GraduateWork.Server.Database {
	public class NinjectDatabaseModule : NinjectModule {
		public override void Load() {
			Kernel?.Bind<IModelDatabase>().To<ModelDatabase>().InSingletonScope();
		}
	}
}