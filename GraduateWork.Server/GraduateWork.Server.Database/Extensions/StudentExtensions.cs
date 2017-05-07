using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Enums;
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
			return ToProxy<StudentBasedProxy>(student);
		}

		public static StudentExtendedProxy[] ToExtendedProxies(this IEnumerable<Student> students) {
			return students.Select(student => student.ToExtendedProxy()).ToArray();
		}
		public static StudentExtendedProxy ToExtendedProxy(this Student student) {
			var studentProxy = ToProxy<StudentExtendedProxy>(student);
			studentProxy.PreviousEducationName = student.PreviousEducationName;
			studentProxy.PreviousEducationYear = student.PreviousEducationYear;
			studentProxy.EnrollmentName = student.EnrollmentName;
			studentProxy.EnrollmentYear = student.EnrollmentYear;
			studentProxy.ExpulsionName = student.ExpulsionName;
			studentProxy.ExpulsionYear = student.ExpulsionYear;
			studentProxy.ExpulsionOrderDate = student.ExpulsionOrderDate;
			studentProxy.ExpulsionOrderNumber = student.ExpulsionOrderNumber;
			studentProxy.DiplomaTopic = student.DiplomaTopic;
			studentProxy.DiplomaAssessment = (Assessment)student.DiplomaAssessment;
			studentProxy.ProtectionDate = student.ProtectionDate;
			studentProxy.ProtocolNumber = student.ProtocolNumber;
			studentProxy.RegistrationNumber = student.RegistrationNumber;
			studentProxy.RegistrationDate = student.RegistrationDate;
			studentProxy.Group = student.Group.ToBasedProxy();
			studentProxy.AssessmentByDisciplines = student.AssessmentByDisciplines.Select(
					assessmentByDiscipline => new AssessmentByDiscipline {
						NameOfDiscipline = assessmentByDiscipline.Discipline.DisciplineName,
						ControlType = assessmentByDiscipline.Discipline.ControlType,
						Assessment = (Assessment)assessmentByDiscipline.Assessment
					})
				.ToArray();

			return studentProxy;
		}

		private static TStudentProxy ToProxy<TStudentProxy>(Student student) where TStudentProxy : StudentBasedProxy, new() {
			return new TStudentProxy {
				FirstName = student.FirstName,
				SecondName = student.SecondName,
				ThirdName = student.ThirdName,
				DateOfBirth = student.DateOfBirth
			};
		}
	}
}