using System.Data.Entity;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer {
	public class ModelDatabase : DbContext, IModelDatabase {
		public DbSet<Group> Groups { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Discipline> Disciplines { get; set; }

		public ModelDatabase() : base("GraduateWorkDatabase") {
		}
	}
}