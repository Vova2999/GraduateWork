using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Tables;
using AssessmentByDiscipline = GraduateWork.Common.Tables.Proxies.Extendeds.AssessmentByDiscipline;

namespace GraduateWork.Server.Database.Extensions {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable UnusedMember.Global

	public static class StudentExtensions {
		public static StudentBasedProxy[] ToBasedProxies(this IEnumerable<Student> students) {
			return students.Select(student => student.ToBasedProxy()).ToArray();
		}
		public static StudentBasedProxy ToBasedProxy(this Student student) {
			return new StudentBasedProxy {
				FirstName = student.FirstName,
				SecondName = student.SecondName,
				ThirdName = student.ThirdName,
				DateOfBirth = student.DateOfBirth
			};
		}

		public static StudentExtendedProxy[] ToExtendedProxies(this IEnumerable<Student> students) {
			return students.Select(student => student.ToExtendedProxy()).ToArray();
		}
		public static StudentExtendedProxy ToExtendedProxy(this Student student) {
			return new StudentExtendedProxy {
				FirstName = student.FirstName,
				SecondName = student.SecondName,
				ThirdName = student.ThirdName,
				DateOfBirth = student.DateOfBirth,
				PreviousEducationName = student.PreviousEducationName,
				PreviousEducationYear = student.PreviousEducationYear,
				EnrollmentName = student.EnrollmentName,
				EnrollmentYear = student.EnrollmentYear,
				DeductionName = student.DeductionName,
				DeductionYear = student.DeductionYear,
				DiplomaTopic = student.DiplomaTopic,
				DiplomaAssessment = student.DiplomaAssessment,
				ProtectionDate = student.ProtectionDate,
				ProtocolNumber = student.ProtocolNumber,
				RegistrationNumber = student.RegistrationNumber,
				RegistrationDate = student.RegistrationDate,
				Group = student.Group.ToBasedProxy(),
				AssessmentByDisciplines = student.AssessmentByDisciplines.Select(
					assessmentByDiscipline => new AssessmentByDiscipline {
						NameOfDiscipline = assessmentByDiscipline.Discipline.DisciplineName,
						Assessment = assessmentByDiscipline.Assessment
					}).ToArray()
			};
		}
	}
}