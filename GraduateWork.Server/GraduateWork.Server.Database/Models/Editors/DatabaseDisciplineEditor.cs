using System.Linq;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Tables;
using AssessmentByDiscipline = GraduateWork.Server.Database.Tables.AssessmentByDiscipline;

namespace GraduateWork.Server.Database.Models.Editors {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseDisciplineEditor : DatabaseEditor, IDatabaseDisciplineEditor {
		public DatabaseDisciplineEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(DisciplineExtendedProxy extendedProxy) {
			var foundGroup = ModelDatabase.GetGroup(extendedProxy.GroupName);
			var newDiscipline = new Discipline {
				DisciplineName = extendedProxy.DisciplineName,
				ControlType = extendedProxy.ControlType,
				TotalHours = extendedProxy.TotalHours,
				ClassHours = extendedProxy.ClassHours,
				Group = foundGroup
			};

			ModelDatabase.Disciplines.Add(newDiscipline);
			ModelDatabase.AssessmentByDisciplines.AddRange(
				foundGroup.Students.Select(student =>
					new AssessmentByDiscipline {
						Student = student,
						Discipline = newDiscipline,
						Group = foundGroup,
						Assessment = (int)Assessment.None
					}));

			ModelDatabase.SaveChanges();
		}
		public void Edit(DisciplineExtendedProxy oldExtendedProxy, DisciplineExtendedProxy newExtendedProxy) {
			var foundDiscipline = ModelDatabase.GetDiscipline(oldExtendedProxy);
			var newGroupDiscipline = ModelDatabase.GetGroup(newExtendedProxy.GroupName);

			foundDiscipline.DisciplineName = newExtendedProxy.DisciplineName;
			foundDiscipline.TotalHours = newExtendedProxy.TotalHours;
			foundDiscipline.ClassHours = newExtendedProxy.ClassHours;
			if (foundDiscipline.ControlType != newExtendedProxy.ControlType) {
				foreach (var assessmentByDiscipline in ModelDatabase.AssessmentByDisciplines.Where(a => a.DisciplineId == foundDiscipline.DisciplineId))
					assessmentByDiscipline.Assessment = (int)Assessment.None;
				foundDiscipline.ControlType = newExtendedProxy.ControlType;
			}
			if (foundDiscipline.GroupId != newGroupDiscipline.GroupId) {
				DeleteAssessmentByDisciplines(assessmentByDiscipline => assessmentByDiscipline.DisciplineId == foundDiscipline.DisciplineId);
				ModelDatabase.AssessmentByDisciplines.AddRange(
					newGroupDiscipline.Students.Select(student =>
						new AssessmentByDiscipline {
							Student = student,
							Discipline = foundDiscipline,
							Group = newGroupDiscipline,
							Assessment = (int)Assessment.None
						}));
				foundDiscipline.Group = newGroupDiscipline;
			}

			ModelDatabase.SaveChanges();
		}
		public void Delete(DisciplineBasedProxy basedProxy) {
			DeleteDiscipline(ModelDatabase.GetDiscipline(basedProxy));
			ModelDatabase.SaveChanges();
		}
	}
}