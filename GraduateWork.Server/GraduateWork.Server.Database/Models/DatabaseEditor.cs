using System;
using System.Collections.Generic;
using System.Linq;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Database.Tables;
using AssessmentByDiscipline = GraduateWork.Server.Database.Tables.AssessmentByDiscipline;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable UnusedMember.Global

	public class DatabaseEditor : IDatabaseEditor {
		private readonly ModelDatabase modelDatabase;

		public DatabaseEditor(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public void AddDiscipline(DisciplineExtendedProxy discipline) {
			var foundGroup = modelDatabase.GetGroup(discipline.GroupName);
			var newDiscipline = new Discipline {
				DisciplineName = discipline.DisciplineName,
				ControlType = discipline.ControlType,
				TotalHours = discipline.TotalHours,
				ClassHours = discipline.ClassHours,
				Group = foundGroup
			};

			modelDatabase.Disciplines.Add(newDiscipline);
			modelDatabase.AssessmentByDisciplines.AddRange(
				foundGroup.Students.Select(student =>
					new AssessmentByDiscipline {
						Student = student,
						Discipline = newDiscipline,
						Group = foundGroup,
						Assessment = (int)Assessment.None
					}));

			modelDatabase.SaveChanges();
		}
		public void EditDiscipline(DisciplineExtendedProxy oldDiscipline, DisciplineExtendedProxy newDiscipline) {
			var foundDiscipline = modelDatabase.GetDiscipline(oldDiscipline);
			var newGroupDiscipline = modelDatabase.GetGroup(newDiscipline.GroupName);

			foundDiscipline.DisciplineName = newDiscipline.DisciplineName;
			foundDiscipline.TotalHours = newDiscipline.TotalHours;
			foundDiscipline.ClassHours = newDiscipline.ClassHours;
			if (foundDiscipline.ControlType != newDiscipline.ControlType) {
				foreach (var assessmentByDiscipline in modelDatabase.AssessmentByDisciplines.Where(a => a.DisciplineId == foundDiscipline.DisciplineId))
					assessmentByDiscipline.Assessment = (int)Assessment.None;
				foundDiscipline.ControlType = newDiscipline.ControlType;
			}
			if (foundDiscipline.GroupId != newGroupDiscipline.GroupId) {
				DeleteAssessmentByDisciplines(assessmentByDiscipline => assessmentByDiscipline.DisciplineId == foundDiscipline.DisciplineId);
				modelDatabase.AssessmentByDisciplines.AddRange(
					newGroupDiscipline.Students.Select(student =>
						new AssessmentByDiscipline {
							Student = student,
							Discipline = foundDiscipline,
							Group = newGroupDiscipline,
							Assessment = (int)Assessment.None
						}));
				foundDiscipline.Group = newGroupDiscipline;
			}

			modelDatabase.SaveChanges();
		}
		public void DeleteDiscipline(DisciplineBasedProxy discipline) {
			DeleteDiscipline(modelDatabase.GetDiscipline(discipline));
			modelDatabase.SaveChanges();
		}

		public void AddGroup(GroupExtendedProxy group) {
			modelDatabase.Groups.Add(new Group {
				GroupName = group.GroupName,
				SpecialtyName = group.SpecialtyName,
				SpecialtyNumber = group.SpecialtyNumber,
				FacultyName = group.FacultyName,
				Students = new List<Student>(),
				Disciplines = new List<Discipline>()
			});

			modelDatabase.SaveChanges();
		}
		public void EditGroup(GroupExtendedProxy oldGroup, GroupExtendedProxy newGroup) {
			var foundGroup = modelDatabase.GetGroup(oldGroup);

			foundGroup.GroupName = newGroup.GroupName;
			foundGroup.SpecialtyName = newGroup.SpecialtyName;
			foundGroup.SpecialtyNumber = newGroup.SpecialtyNumber;
			foundGroup.FacultyName = newGroup.FacultyName;

			modelDatabase.SaveChanges();
		}
		public void DeleteGroup(GroupBasedProxy group) {
			DeleteGroup(modelDatabase.GetGroup(group));
			modelDatabase.SaveChanges();
		}

		public void AddStudent(StudentExtendedProxy student) {
			var foundGroup = modelDatabase.GetGroup(student.Group);
			var newStudent = new Student {
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
				DiplomaAssessment = (int)student.DiplomaAssessment,
				ProtectionDate = student.ProtectionDate,
				ProtocolNumber = student.ProtocolNumber,
				RegistrationNumber = student.RegistrationNumber,
				RegistrationDate = student.RegistrationDate,
				Group = foundGroup
			};
			newStudent.AssessmentByDisciplines = newStudent.Group.Disciplines.Select(discipline =>
				new AssessmentByDiscipline {
					Student = newStudent,
					Discipline = discipline,
					Group = foundGroup,
					Assessment = (int)student.AssessmentByDisciplines.First(a => a.NameOfDiscipline == discipline.DisciplineName).Assessment
				}).ToList();

			modelDatabase.Students.Add(newStudent);
			modelDatabase.SaveChanges();
		}
		public void EditStudent(StudentExtendedProxy oldStudent, StudentExtendedProxy newStudent) {
			var foundStudent = modelDatabase.GetStudent(oldStudent);

			foundStudent.FirstName = newStudent.FirstName;
			foundStudent.SecondName = newStudent.SecondName;
			foundStudent.ThirdName = newStudent.ThirdName;
			foundStudent.DateOfBirth = newStudent.DateOfBirth;
			foundStudent.PreviousEducationName = newStudent.PreviousEducationName;
			foundStudent.PreviousEducationYear = newStudent.PreviousEducationYear;
			foundStudent.EnrollmentName = newStudent.EnrollmentName;
			foundStudent.EnrollmentYear = newStudent.EnrollmentYear;
			foundStudent.DeductionName = newStudent.DeductionName;
			foundStudent.DeductionYear = newStudent.DeductionYear;
			foundStudent.DiplomaTopic = newStudent.DiplomaTopic;
			foundStudent.DiplomaAssessment = (int)newStudent.DiplomaAssessment;
			foundStudent.ProtectionDate = newStudent.ProtectionDate;
			foundStudent.ProtocolNumber = newStudent.ProtocolNumber;
			foundStudent.RegistrationNumber = newStudent.RegistrationNumber;
			foundStudent.RegistrationDate = newStudent.RegistrationDate;
			foundStudent.AssessmentByDisciplines.ForEach(assessmentByDiscipline =>
				assessmentByDiscipline.Assessment = (int)newStudent.AssessmentByDisciplines.First(a =>
					a.NameOfDiscipline == assessmentByDiscipline.Discipline.DisciplineName).Assessment);

			modelDatabase.SaveChanges();
		}
		public void DeleteStudent(StudentBasedProxy student) {
			DeleteStudent(modelDatabase.GetStudent(student));
			modelDatabase.SaveChanges();
		}

		public void AddUser(UserExtendedProxy user) {
			modelDatabase.Users.Add(new User {
				Login = user.Login,
				Password = user.Password,
				AccessType = user.AccessType
			});

			modelDatabase.SaveChanges();
		}
		public void EditUser(UserExtendedProxy oldUser, UserExtendedProxy newUser) {
			var foundUser = modelDatabase.GetUser(oldUser);

			foundUser.Login = newUser.Login;
			foundUser.Password = newUser.Password;
			foundUser.AccessType = newUser.AccessType;

			modelDatabase.SaveChanges();
		}
		public void DeleteUser(UserBasedProxy user) {
			var foundUser = modelDatabase.GetUser(user);
			modelDatabase.Users.Remove(foundUser);
			modelDatabase.SaveChanges();
		}

		private void DeleteDiscipline(Discipline discipline) {
			DeleteAssessmentByDisciplines(assessmentByDiscipline => assessmentByDiscipline.DisciplineId == discipline.DisciplineId);
			modelDatabase.Disciplines.Remove(discipline);
		}
		private void DeleteGroup(Group group) {
			modelDatabase.Students.Where(student => student.GroupId == group.GroupId).ToList().ForEach(DeleteStudent);
			modelDatabase.Disciplines.Where(discipline => discipline.GroupId == group.GroupId).ToList().ForEach(DeleteDiscipline);
			modelDatabase.Groups.Remove(group);
		}
		private void DeleteStudent(Student student) {
			DeleteAssessmentByDisciplines(assessmentByDiscipline => assessmentByDiscipline.StudentId == student.StudentId);
			modelDatabase.Students.Remove(student);
		}
		private void DeleteAssessmentByDisciplines(Func<AssessmentByDiscipline, bool> predicate) {
			modelDatabase.AssessmentByDisciplines.RemoveRange(modelDatabase.AssessmentByDisciplines.Where(predicate));
		}
	}
}