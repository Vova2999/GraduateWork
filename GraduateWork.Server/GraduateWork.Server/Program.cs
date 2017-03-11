using System;
using System.Runtime.InteropServices;
using GraduateWork.Server.Server;
using Ninject;
using Ninject.Extensions.Conventions;

namespace GraduateWork.Server {
	public static class Program {
		public static void Main() {
			CreateHttpServer().Run();
		}

		private static IHttpServer CreateHttpServer() {
			var container = new StandardKernel();

			container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
			container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses());

			return container.Get<HttpServer>();
		}
	}
}
