using System;
using System.Runtime.InteropServices;
using GraduateWork.Server.Server;
using Ninject;
using Ninject.Extensions.Conventions;

namespace GraduateWork.Server {
	public static class Program {
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int mCmdShow);

		private const int swHide = 0;
		private const int swShow = 5;

		public static void Main(string[] args) {
			var handle = GetConsoleWindow();
			ShowWindow(handle, swHide);

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
