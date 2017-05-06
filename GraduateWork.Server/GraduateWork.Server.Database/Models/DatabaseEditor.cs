using System;
using System.Linq;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable UnusedMember.Global

	public abstract class DatabaseEditor {
		protected readonly ModelDatabase ModelDatabase;

		protected DatabaseEditor(ModelDatabase modelDatabase) {
			ModelDatabase = modelDatabase;
		}

		protected void DeleteDiscipline(Discipline discipline) {
			DeleteAssessmentByDisciplines(assessmentByDiscipline => assessmentByDiscipline.DisciplineId == discipline.DisciplineId);
			ModelDatabase.Disciplines.Remove(discipline);
		}
		protected void DeleteGroup(Group group) {
			ModelDatabase.Students.Where(student => student.GroupId == group.GroupId).ToList().ForEach(DeleteStudent);
			ModelDatabase.Disciplines.Where(discipline => discipline.GroupId == group.GroupId).ToList().ForEach(DeleteDiscipline);
			ModelDatabase.Groups.Remove(group);
		}
		protected void DeleteStudent(Student student) {
			DeleteAssessmentByDisciplines(assessmentByDiscipline => assessmentByDiscipline.StudentId == student.StudentId);
			ModelDatabase.Students.Remove(student);
		}
		protected void DeleteAssessmentByDisciplines(Func<AssessmentByDiscipline, bool> predicate) {
			ModelDatabase.AssessmentByDisciplines.RemoveRange(ModelDatabase.AssessmentByDisciplines.Where(predicate));
		}
	}
}