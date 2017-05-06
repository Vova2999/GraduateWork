using System.Linq;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Tables;
using AssessmentByDiscipline = GraduateWork.Server.Database.Tables.AssessmentByDiscipline;

namespace GraduateWork.Server.Database.Models.Editors {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseStudentEditor : DatabaseEditor, IDatabaseStudentEditor {
		public DatabaseStudentEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(StudentExtendedProxy extendedProxy) {
			var foundGroup = ModelDatabase.GetGroup(extendedProxy.Group);
			var newStudent = new Student {
				FirstName = extendedProxy.FirstName,
				SecondName = extendedProxy.SecondName,
				ThirdName = extendedProxy.ThirdName,
				DateOfBirth = extendedProxy.DateOfBirth,
				PreviousEducationName = extendedProxy.PreviousEducationName,
				PreviousEducationYear = extendedProxy.PreviousEducationYear,
				EnrollmentName = extendedProxy.EnrollmentName,
				EnrollmentYear = extendedProxy.EnrollmentYear,
				DeductionName = extendedProxy.DeductionName,
				DeductionYear = extendedProxy.DeductionYear,
				DiplomaTopic = extendedProxy.DiplomaTopic,
				DiplomaAssessment = (int)extendedProxy.DiplomaAssessment,
				ProtectionDate = extendedProxy.ProtectionDate,
				ProtocolNumber = extendedProxy.ProtocolNumber,
				RegistrationNumber = extendedProxy.RegistrationNumber,
				RegistrationDate = extendedProxy.RegistrationDate,
				Group = foundGroup
			};
			newStudent.AssessmentByDisciplines = newStudent.Group.Disciplines.Select(discipline =>
					new AssessmentByDiscipline {
						Student = newStudent,
						Discipline = discipline,
						Group = foundGroup,
						Assessment = (int)extendedProxy.AssessmentByDisciplines.First(a => a.NameOfDiscipline == discipline.DisciplineName).Assessment
					})
				.ToList();

			ModelDatabase.Students.Add(newStudent);
			ModelDatabase.SaveChanges();
		}
		public void Edit(StudentExtendedProxy oldExtendedProxy, StudentExtendedProxy newExtendedProxy) {
			var foundStudent = ModelDatabase.GetStudent(oldExtendedProxy);

			foundStudent.FirstName = newExtendedProxy.FirstName;
			foundStudent.SecondName = newExtendedProxy.SecondName;
			foundStudent.ThirdName = newExtendedProxy.ThirdName;
			foundStudent.DateOfBirth = newExtendedProxy.DateOfBirth;
			foundStudent.PreviousEducationName = newExtendedProxy.PreviousEducationName;
			foundStudent.PreviousEducationYear = newExtendedProxy.PreviousEducationYear;
			foundStudent.EnrollmentName = newExtendedProxy.EnrollmentName;
			foundStudent.EnrollmentYear = newExtendedProxy.EnrollmentYear;
			foundStudent.DeductionName = newExtendedProxy.DeductionName;
			foundStudent.DeductionYear = newExtendedProxy.DeductionYear;
			foundStudent.DiplomaTopic = newExtendedProxy.DiplomaTopic;
			foundStudent.DiplomaAssessment = (int)newExtendedProxy.DiplomaAssessment;
			foundStudent.ProtectionDate = newExtendedProxy.ProtectionDate;
			foundStudent.ProtocolNumber = newExtendedProxy.ProtocolNumber;
			foundStudent.RegistrationNumber = newExtendedProxy.RegistrationNumber;
			foundStudent.RegistrationDate = newExtendedProxy.RegistrationDate;
			foundStudent.AssessmentByDisciplines.ForEach(assessmentByDiscipline =>
				assessmentByDiscipline.Assessment = (int)newExtendedProxy.AssessmentByDisciplines.First(a =>
						a.NameOfDiscipline == assessmentByDiscipline.Discipline.DisciplineName)
					.Assessment);

			ModelDatabase.SaveChanges();
		}
		public void Delete(StudentBasedProxy basedProxy) {
			DeleteStudent(ModelDatabase.GetStudent(basedProxy));
			ModelDatabase.SaveChanges();
		}
	}
}