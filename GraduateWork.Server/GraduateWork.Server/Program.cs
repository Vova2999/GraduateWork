﻿using System.Data.Entity;
using GraduateWork.Server.Common;
using GraduateWork.Server.Database;
using GraduateWork.Server.Server;
using Ninject;
using Ninject.Extensions.Conventions;

namespace GraduateWork.Server {
	public static class Program {
		public static void Main() {
			System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelDatabase>());

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