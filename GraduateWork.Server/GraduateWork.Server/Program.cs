﻿using GraduateWork.Server.Database;
using GraduateWork.Server.Reports;
using GraduateWork.Server.Server;
using Ninject;
using Ninject.Extensions.Conventions;

namespace GraduateWork.Server {
	public static class Program {
		public static void Main(params string[] args) {
			CreateHttpServer().Run(args[0]);
		}

		private static IHttpServer CreateHttpServer() {
			var container = new StandardKernel(new NinjectDatabaseModule(), new NinjectReportsModule());

			container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
			container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses());

			return container.Get<IHttpServer>();
		}
	}
}