using System.Data.Entity;
using GraduateWork.Server.DataAccessLayer;
using GraduateWork.Server.Server;
using Ninject;
using Ninject.Extensions.Conventions;

namespace GraduateWork.Server {
	public static class Program {
		public static void Main() {
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelDatabase>());

			CreateHttpServer().Run();
		}

		private static IHttpServer CreateHttpServer() {
			var container = new StandardKernel();

			container.Bind<IModelDatabase>().To<ModelDatabase>().InSingletonScope();
			container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
			container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses());

			return container.Get<IHttpServer>();
		}
	}
}