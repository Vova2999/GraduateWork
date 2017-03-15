using System.Data.Entity;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer {
	public interface IModelDatabase {
		DbSet<Group> Groups { get; }
		DbSet<Student> Students { get; }
		DbSet<Discipline> Disciplines { get; }

		void AddGroup(GroupProxy groupProxy);
		void EditGroup(GroupProxy oldGroupProxy, GroupProxy newGroupProxy);
		void DeleteGroup(GroupProxy groupProxy);
	}
}