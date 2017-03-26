using GraduateWork.Server.Common;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace GraduateWork.Server.Reports {
	public class NinjectReportsModule : NinjectModule {
		public override void Load() {
			Kernel?.Bind<IReportsCreator>().To<ReportsCreator>().InSingletonScope();
			Kernel?.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses());
		}
	}
}