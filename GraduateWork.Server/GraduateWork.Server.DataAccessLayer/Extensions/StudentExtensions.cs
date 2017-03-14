using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;
using Assessment = GraduateWork.Common.Tables.Proxies.Assessment;
using AssessmentByDiscipline = GraduateWork.Common.Tables.Proxies.AssessmentByDiscipline;

namespace GraduateWork.Server.DataAccessLayer.Extensions {
	public static class StudentExtensions {
		public static IEnumerable<StudentProxy> ToProxies(this IEnumerable<Student> students) {
			return students.Select(student => student.ToProxy());
		}

		private static StudentProxy ToProxy(this Student student) {
			return new StudentProxy {
				FirstName = student.FirstName,
				SecondName = student.SecondName,
				ThirdName = student.ThirdName,
				YearOfReceipt = student.YearOfReceipt,
				YearOfDeduction = student.YearOfDeduction,
				NameOfGroup = student.Group.NameOfGroup,
				AssessmentByDisciplines = student.AssessmentByDisciplines
					.Select(assessmentByDiscipline => new AssessmentByDiscipline {
						NameOfDiscipline = assessmentByDiscipline.Discipline.NameOfDiscipline,
						Assessment = (Assessment)(int)assessmentByDiscipline.Assessment
					}).ToArray()
			};
		}
	}
}