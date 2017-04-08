using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using GraduateWork.Common.Tables.Proxies.Baseds;
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
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}

		public Discipline GetDiscipline(DisciplineBasedProxy discipline) {
			return Disciplines.First(d =>
				d.DisciplineName == discipline.DisciplineName && d.Group == GetGroup(discipline.Group));
		}
		public Group GetGroup(GroupBasedProxy group) {
			return Groups.First(g => g.GroupName == group.GroupName);
		}
		public Student GetStudent(StudentBasedProxy student) {
			return Students.First(s =>
				s.FirstName == student.FirstName &&
					s.SecondName == student.SecondName &&
					s.ThirdName == student.ThirdName &&
					s.DateOfBirth == student.DateOfBirth);
		}
		public User GetUser(UserBasedProxy user) {
			return Users.First(u => u.Login == user.Login && u.Password == user.Password);
		}
	}
}