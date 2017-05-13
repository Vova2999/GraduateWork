using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace GraduateWork.Server.Reports {
	public class NinjectReportsModule : NinjectModule {
		public override void Load() {
			Kernel?.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces().Configure(y => y.InSingletonScope()));
			Kernel?.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses().Configure(y => y.InSingletonScope()));
		}
	}
}