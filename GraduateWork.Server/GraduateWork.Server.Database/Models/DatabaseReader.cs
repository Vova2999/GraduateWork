using System;
using System.Linq;
using System.Linq.Expressions;

namespace GraduateWork.Server.Database.Models {
	public abstract class DatabaseReader {
		protected static void UseFilter<TTable>(bool useFilter, ref IQueryable<TTable> table, Expression<Func<TTable, bool>> predicate) {
			table = useFilter ? table.Where(predicate) : table;
		}
	}
}