using System.Data.Entity;
using GraduateWork.Server.Database.Models;
using GraduateWork.Server.Database.Models.Editors;
using GraduateWork.Server.Database.Models.Readers;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace GraduateWork.Server.Database {
	public class NinjectDatabaseModule : NinjectModule {
		public override void Load() {
			System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelDatabase>());

			Kernel?.Bind<ModelDatabase>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseDisciplineEditor>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseGroupEditor>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseStudentEditor>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseUserEditor>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseAssessmentByDisciplinesReader>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseDisciplineReader>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseGroupReader>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseStudentReader>().ToSelf().InSingletonScope();
			Kernel?.Bind<DatabaseUserReader>().ToSelf().InSingletonScope();
			Kernel?.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
		}
	}
}