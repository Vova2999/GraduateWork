using System;
using System.Linq;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Extensions;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models.Readers {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseStudentReader : DatabaseReader, IDatabaseStudentReader {
		private readonly ModelDatabase modelDatabase;

		public DatabaseStudentReader(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public StudentBasedProxy[] GetAllBasedProies() {
			return modelDatabase.Students.ToBasedProxies();
		}
		public StudentExtendedProxy GetExtendedProxy(StudentBasedProxy basedProxy) {
			return modelDatabase.GetStudent(basedProxy).ToExtendedProxy();
		}
		public StudentBasedProxy[] GetStudentsWithUsingFilters(string firstName, string secondName, string thirdName, DateTime? dateOfBirth) {
			IQueryable<Student> students = modelDatabase.Students;
			UseFilter(firstName != null, ref students, student => student.FirstName.Contains(firstName));
			UseFilter(secondName != null, ref students, student => student.SecondName.Contains(secondName));
			UseFilter(thirdName != null, ref students, student => student.ThirdName.Contains(thirdName));
			UseFilter(dateOfBirth != null, ref students, student => student.DateOfBirth == dateOfBirth);

			return students.ToBasedProxies();
		}
	}
}