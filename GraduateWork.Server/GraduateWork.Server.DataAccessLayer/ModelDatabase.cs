using System.Data.Entity;
using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer {
	public class ModelDatabase : DbContext, IModelDatabase {
		public DbSet<Group> Groups { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Discipline> Disciplines { get; set; }

		public ModelDatabase() : base("GraduateWorkDatabase") {
		}

		public void AddGroup(GroupProxy groupProxy) {
			Groups.Add(new Group {
				NameOfGroup = groupProxy.NameOfGroup
			});

			SaveChanges();
		}
		public void EditGroup(GroupProxy oldGroupProxy, GroupProxy newGroupProxy) {
			var foundGroup = Groups.First(group => group.NameOfGroup == oldGroupProxy.NameOfGroup);
			foundGroup.NameOfGroup = newGroupProxy.NameOfGroup;

			SaveChanges();
		}
		public void DeleteGroup(GroupProxy groupProxy) {
			var foundGroup = Groups.First(group => group.NameOfGroup == groupProxy.NameOfGroup);
			Groups.Remove(foundGroup);

			SaveChanges();
		}
	}
}