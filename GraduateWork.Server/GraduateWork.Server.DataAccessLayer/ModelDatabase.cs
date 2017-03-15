﻿using System.Data.Entity;
using System.Linq;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Server.DataAccessLayer.Tables;
using Assessment = GraduateWork.Server.DataAccessLayer.Tables.Assessment;
using AssessmentByDiscipline = GraduateWork.Server.DataAccessLayer.Tables.AssessmentByDiscipline;

namespace GraduateWork.Server.DataAccessLayer {
	public class ModelDatabase : DbContext, IModelDatabase {
		public DbSet<Group> Groups { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Discipline> Disciplines { get; set; }
		public DbSet<AssessmentByDiscipline> AssessmentByDisciplines { get; set; }

		public ModelDatabase() : base("GraduateWorkDatabase") {
		}

		public void AddGroup(GroupProxy groupProxy) {
			Groups.Add(new Group {
				NameOfGroup = groupProxy.NameOfGroup
			});

			SaveChanges();
		}
		public void EditGroup(GroupProxy oldGroupProxy, GroupProxy newGroupProxy) {
			var foundGroup = Groups.First(group => group.NameOfGroup == oldGroupProxy.NameOfGroup);
			foundGroup.NameOfGroup = newGroupProxy.NameOfGroup;

			SaveChanges();
		}
		public void DeleteGroup(GroupProxy groupProxy) {
			var foundGroup = Groups.First(group => group.NameOfGroup == groupProxy.NameOfGroup);
			Groups.Remove(foundGroup);

			SaveChanges();
		}

		public void AddDiscipline(DisciplineProxy disciplineProxy) {
			Disciplines.Add(new Discipline {
				NameOfDiscipline = disciplineProxy.NameOfDiscipline
			});

			SaveChanges();
		}
		public void EditDiscipline(DisciplineProxy oldDisciplineProxy, DisciplineProxy newDisciplineProxy) {
			var foundDiscipline = Disciplines.First(discipline => discipline.NameOfDiscipline == oldDisciplineProxy.NameOfDiscipline);
			foundDiscipline.NameOfDiscipline = newDisciplineProxy.NameOfDiscipline;

			SaveChanges();
		}
		public void DeleteDiscipline(DisciplineProxy disciplineProxy) {
			var foundDiscipline = Disciplines.First(discipline => discipline.NameOfDiscipline == disciplineProxy.NameOfDiscipline);
			Disciplines.Remove(foundDiscipline);

			SaveChanges();
		}

		public void AddStudent(StudentProxy studentProxy) {
			var student = new Student {
				FirstName = studentProxy.FirstName,
				SecondName = studentProxy.SecondName,
				ThirdName = studentProxy.ThirdName,
				DateOfReceipt = studentProxy.DateOfReceipt,
				DateOfDeduction = studentProxy.DateOfDeduction,
				Group = Groups.First(group => group.NameOfGroup == studentProxy.NameOfGroup)
			};
			student.AssessmentByDisciplines = studentProxy.AssessmentByDisciplines
				.Select(assessmentByDisciplines => new AssessmentByDiscipline {
					Student = student,
					Discipline = Disciplines.First(discipline => discipline.NameOfDiscipline == assessmentByDisciplines.NameOfDiscipline),
					Assessment = (Assessment)assessmentByDisciplines.Assessment
				}).ToList();

			Students.Add(student);

			SaveChanges();
		}
		public void EditStudent(StudentProxy oldStudentProxy, StudentProxy newStudentProxy) {
			var foundStudent = Students.First(student => student.FirstName == oldStudentProxy.FirstName &&
				student.SecondName == oldStudentProxy.SecondName && student.ThirdName == oldStudentProxy.ThirdName);

			foundStudent.FirstName = newStudentProxy.FirstName;
			foundStudent.SecondName = newStudentProxy.SecondName;
			foundStudent.ThirdName = newStudentProxy.ThirdName;
			foundStudent.DateOfReceipt = newStudentProxy.DateOfReceipt;
			foundStudent.DateOfDeduction = newStudentProxy.DateOfDeduction;
			foundStudent.Group = Groups.First(group => group.NameOfGroup == newStudentProxy.NameOfGroup);
			foundStudent.AssessmentByDisciplines = newStudentProxy.AssessmentByDisciplines
				.Select(assessmentByDisciplines => new AssessmentByDiscipline {
					Student = foundStudent,
					Discipline = Disciplines.First(discipline => discipline.NameOfDiscipline == assessmentByDisciplines.NameOfDiscipline),
					Assessment = (Assessment)assessmentByDisciplines.Assessment
				}).ToList();

			SaveChanges();
		}
		public void DeleteStudent(StudentProxy studentProxy) {
			var foundStudent = Students.First(student => student.FirstName == studentProxy.FirstName &&
				student.SecondName == studentProxy.SecondName && student.ThirdName == studentProxy.ThirdName);
			Students.Remove(foundStudent);

			SaveChanges();
		}
	}
}