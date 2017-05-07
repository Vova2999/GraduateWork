using GraduateWork.Server.Reports.Creators;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace GraduateWork.Server.Reports {
	public class NinjectReportsModule : NinjectModule {
		public override void Load() {
			Kernel?.Bind<ReportsCreator>().ToSelf().InSingletonScope();
			Kernel?.Bind<AcademCreator>().ToSelf().InSingletonScope();
			Kernel?.Bind<DiplomaCreator>().ToSelf().InSingletonScope();
			Kernel?.Bind<DiplomaSupplementCreator>().ToSelf().InSingletonScope();
			Kernel?.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
			Kernel?.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses());
		}
	}
}