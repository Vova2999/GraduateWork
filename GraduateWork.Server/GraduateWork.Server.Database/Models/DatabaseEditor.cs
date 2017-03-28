using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.Common.Database;
using GraduateWork.Server.Database.Tables;
using Assessment = GraduateWork.Server.Database.Tables.Assessment;
using AssessmentByDiscipline = GraduateWork.Server.Database.Tables.AssessmentByDiscipline;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseEditor : IDatabaseEditor {
		private readonly ModelDatabase modelDatabase;

		public DatabaseEditor(ModelDatabase modelDatabase) {
			this.modelDatabase = modelDatabase;
		}

		public void AddGroup(GroupProxy groupProxy) {
			modelDatabase.Groups.Add(new Group {
				NameOfGroup = groupProxy.NameOfGroup
			});

			modelDatabase.SaveChanges();
		}
		public void EditGroup(GroupProxy oldGroupProxy, GroupProxy newGroupProxy) {
			var foundGroup = modelDatabase.Groups.First(group => group.NameOfGroup == oldGroupProxy.NameOfGroup);
			foundGroup.NameOfGroup = newGroupProxy.NameOfGroup;

			modelDatabase.SaveChanges();
		}
		public void DeleteGroup(GroupProxy groupProxy) {
			var foundGroup = modelDatabase.Groups.First(group => group.NameOfGroup == groupProxy.NameOfGroup);
			modelDatabase.Groups.Remove(foundGroup);

			modelDatabase.SaveChanges();
		}

		public void AddStudent(StudentProxy studentProxy) {
			var student = new Student {
				FirstName = studentProxy.FirstName,
				SecondName = studentProxy.SecondName,
				ThirdName = studentProxy.ThirdName,
				DateOfReceipt = studentProxy.DateOfReceipt,
				DateOfDeduction = studentProxy.DateOfDeduction,
				Group = modelDatabase.Groups.First(group => group.NameOfGroup == studentProxy.NameOfGroup)
			};
			student.AssessmentByDisciplines = studentProxy.AssessmentByDisciplines
				.Select(assessmentByDisciplines => new AssessmentByDiscipline {
					Student = student,
					Discipline = modelDatabase.Disciplines.First(discipline => discipline.NameOfDiscipline == assessmentByDisciplines.NameOfDiscipline),
					Assessment = (Assessment)assessmentByDisciplines.Assessment
				}).ToList();

			modelDatabase.Students.Add(student);

			modelDatabase.SaveChanges();
		}
		public void EditStudent(StudentProxy oldStudentProxy, StudentProxy newStudentProxy) {
			var foundStudent = modelDatabase.Students.First(student => student.FirstName == oldStudentProxy.FirstName &&
				student.SecondName == oldStudentProxy.SecondName && student.ThirdName == oldStudentProxy.ThirdName);
			modelDatabase.AssessmentByDisciplines.RemoveRange(foundStudent.AssessmentByDisciplines);

			foundStudent.FirstName = newStudentProxy.FirstName;
			foundStudent.SecondName = newStudentProxy.SecondName;
			foundStudent.ThirdName = newStudentProxy.ThirdName;
			foundStudent.DateOfReceipt = newStudentProxy.DateOfReceipt;
			foundStudent.DateOfDeduction = newStudentProxy.DateOfDeduction;
			foundStudent.Group = modelDatabase.Groups.First(group => group.NameOfGroup == newStudentProxy.NameOfGroup);
			foundStudent.AssessmentByDisciplines = newStudentProxy.AssessmentByDisciplines
				.Select(assessmentByDisciplines => new AssessmentByDiscipline {
					Student = foundStudent,
					Discipline = modelDatabase.Disciplines.First(discipline => discipline.NameOfDiscipline == assessmentByDisciplines.NameOfDiscipline),
					Assessment = (Assessment)assessmentByDisciplines.Assessment
				}).ToList();

			modelDatabase.SaveChanges();
		}
		public void DeleteStudent(StudentProxy studentProxy) {
			var foundStudent = modelDatabase.Students.First(student => student.FirstName == studentProxy.FirstName &&
				student.SecondName == studentProxy.SecondName && student.ThirdName == studentProxy.ThirdName);
			modelDatabase.AssessmentByDisciplines.RemoveRange(foundStudent.AssessmentByDisciplines);
			modelDatabase.Students.Remove(foundStudent);

			modelDatabase.SaveChanges();
		}

		public void AddDiscipline(DisciplineProxy disciplineProxy) {
			modelDatabase.Disciplines.Add(new Discipline {
				NameOfDiscipline = disciplineProxy.NameOfDiscipline
			});

			modelDatabase.SaveChanges();
		}
		public void EditDiscipline(DisciplineProxy oldDisciplineProxy, DisciplineProxy newDisciplineProxy) {
			var foundDiscipline = modelDatabase.Disciplines.First(discipline => discipline.NameOfDiscipline == oldDisciplineProxy.NameOfDiscipline);
			foundDiscipline.NameOfDiscipline = newDisciplineProxy.NameOfDiscipline;

			modelDatabase.SaveChanges();
		}
		public void DeleteDiscipline(DisciplineProxy disciplineProxy) {
			var foundDiscipline = modelDatabase.Disciplines.First(discipline => discipline.NameOfDiscipline == disciplineProxy.NameOfDiscipline);
			modelDatabase.Disciplines.Remove(foundDiscipline);

			modelDatabase.SaveChanges();
		}

		public void AddUser(UserProxy userProxy) {
			modelDatabase.Users.Add(new User {
				Login = userProxy.Login,
				Password = userProxy.Password,
				AccessType = userProxy.AccessType
			});

			modelDatabase.SaveChanges();
		}
		public void EditUser(UserProxy oldUserProxy, UserProxy newUserProxy) {
			var foundUser = modelDatabase.Users.First(user => user.Login == oldUserProxy.Login && user.Password == oldUserProxy.Password);
			foundUser.Login = newUserProxy.Login;
			foundUser.Password = newUserProxy.Password;
			foundUser.AccessType = newUserProxy.AccessType;

			modelDatabase.SaveChanges();
		}
		public void DeleteUser(UserProxy userProxy) {
			var foundUser = modelDatabase.Users.First(user => user.Login == userProxy.Login && user.Password == userProxy.Password);
			modelDatabase.Users.Remove(foundUser);

			modelDatabase.SaveChanges();
		}
	}
}