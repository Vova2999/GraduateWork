using System.Collections.Generic;
using System.Linq;
using GraduateWork.Server.DataAccessLayer.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;

namespace GraduateWork.Server.DataAccessLayer.Extensions {
	public static class StudentExtensions {
		public static StudentProxy[] ToProxies(this IEnumerable<Student> students) {
			return students.Select(student => student.ToProxy()).ToArray();
		}

		private static StudentProxy ToProxy(this Student student) {
			return new StudentProxy() {
				FirstName = student.FirstName,
				SecondName = student.SecondName,
				ThirdName = student.ThirdName,
				YearOfReceipt = student.YearOfReceipt,
				YearOfDeduction = student.YearOfDeduction,
				NameOfGroup = student.Group.NameOfGroup,
				NameOfDisciplines = student.Disciplines.Select(discipline => discipline.NameOfDiscipline).ToArray()
			};
		}
	}
}