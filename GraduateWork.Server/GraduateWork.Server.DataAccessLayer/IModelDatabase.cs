using System.Data.Entity;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer {
	public interface IModelDatabase {
		DbSet<Group> Groups { get; }
		DbSet<Student> Students { get; }
		DbSet<Discipline> Disciplines { get; }
	}
}