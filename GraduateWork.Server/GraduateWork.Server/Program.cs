using System;
using GraduateWork.Server.Database;
using GraduateWork.Server.Reports;
using GraduateWork.Server.Server;
using Ninject;
using Ninject.Extensions.Conventions;

namespace GraduateWork.Server {
	public static class Program {
		public static void Main() {
			try {
				RunServer();
			}
			catch (Exception) {
				// ignored
			}
		}
		public static void RunServer() {
			CreateHttpServer().Run(ServerSettings.ReadSettings().ServerAddress);
		}
		private static IHttpServer CreateHttpServer() {
			var container = new StandardKernel(new NinjectDatabaseModule(), new NinjectReportsModule());

			container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
			container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses());

			return container.Get<IHttpServer>();
		}
	}
}