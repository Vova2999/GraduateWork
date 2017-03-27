using System.Data.Entity;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable UnusedAutoPropertyAccessor.Global

	public class ModelDatabase : DbContext {
		public DbSet<User> Users { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Discipline> Disciplines { get; set; }
		public DbSet<AssessmentByDiscipline> AssessmentByDisciplines { get; set; }

		public ModelDatabase() : base("GraduateWorkDatabase") {
			System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelDatabase>());
		}
	}
}