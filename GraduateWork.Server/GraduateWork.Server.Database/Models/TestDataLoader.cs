using System;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Server.Database.Models {
	// ReSharper disable ClassNeverInstantiated.Global

	public class TestDataLoader {
		private readonly IDatabaseDisciplineEditor databaseDisciplineEditor;
		private readonly IDatabaseGroupEditor databaseGroupEditor;
		private readonly IDatabaseStudentEditor databaseStudentEditor;
		private readonly IDatabaseDisciplineReader databaseDisciplineReader;
		private readonly IDatabaseGroupReader databaseGroupReader;
		private readonly IDatabaseStudentReader databaseStudentReader;

		public TestDataLoader(IDatabaseDisciplineEditor databaseDisciplineEditor,
							  IDatabaseGroupEditor databaseGroupEditor,
							  IDatabaseStudentEditor databaseStudentEditor,
							  IDatabaseDisciplineReader databaseDisciplineReader,
							  IDatabaseGroupReader databaseGroupReader,
							  IDatabaseStudentReader databaseStudentReader) {
			this.databaseDisciplineEditor = databaseDisciplineEditor;
			this.databaseGroupEditor = databaseGroupEditor;
			this.databaseStudentEditor = databaseStudentEditor;
			this.databaseDisciplineReader = databaseDisciplineReader;
			this.databaseGroupReader = databaseGroupReader;
			this.databaseStudentReader = databaseStudentReader;
		}

		public void Load() {
			DeleteAllData();
			LoadNewData();
		}
		private void DeleteAllData() {
			foreach (var student in databaseStudentReader.GetAllBasedProies())
				databaseStudentEditor.Delete(student);
			foreach (var discipline in databaseDisciplineReader.GetAllBasedProies())
				databaseDisciplineEditor.Delete(discipline);
			foreach (var group in databaseGroupReader.GetAllBasedProies())
				databaseGroupEditor.Delete(group);
		}
		private void LoadNewData() {
			var group = new GroupExtendedProxy {
				GroupName = "Б08-191-2",
				SpecialtyNumber = 231000,
				SpecialtyName = "Программная инженерия",
				FacultyName = "Информатика и вычислительная техника"
			};

			databaseGroupEditor.Add(group);

			databaseDisciplineEditor.Add(new DisciplineExtendedProxy {
				DisciplineName = "Английский язык",
				ControlType = ControlType.Exam,
				GroupName = group.GroupName,
				ClassHours = 32,
				TotalHours = 48
			});
			databaseDisciplineEditor.Add(new DisciplineExtendedProxy {
				DisciplineName = "Архитектура ЭВМ",
				ControlType = ControlType.CourseWork,
				GroupName = group.GroupName,
				ClassHours = 0,
				TotalHours = 0
			});
			databaseDisciplineEditor.Add(new DisciplineExtendedProxy {
				DisciplineName = "Физика",
				ControlType = ControlType.Credit,
				GroupName = group.GroupName,
				ClassHours = 32,
				TotalHours = 48
			});
			databaseDisciplineEditor.Add(new DisciplineExtendedProxy {
				DisciplineName = "Вычислительная математика",
				ControlType = ControlType.Credit,
				GroupName = group.GroupName,
				ClassHours = 16,
				TotalHours = 16
			});
			databaseDisciplineEditor.Add(new DisciplineExtendedProxy {
				DisciplineName = "Инженерная графика",
				ControlType = ControlType.CourseWork,
				GroupName = group.GroupName,
				ClassHours = 0,
				TotalHours = 0
			});

			databaseStudentEditor.Add(new StudentExtendedProxy {
				FirstName = "Владимир",
				SecondName = "Новоселов",
				ThirdName = "Олегович",
				DateOfBirth = new DateTime(1995, 8, 9),
				PreviousEducationName = "аттестат о среднем (полном) общем образовании",
				PreviousEducationYear = 2011,
				EnrollmentName = "государственное образовательное учреждение высшего профессионального образования \"Ижевский государственный технический университет\" (очная форма)",
				EnrollmentYear = 2011,
				DeductionName = "федеральном государственном бюджетном образовательном учреждении высшего профессионального образования \"Ижевский государственный технический университет\" (очная форма)",
				DeductionYear = 2015,
				DiplomaTopic = "Эта программа",
				DiplomaAssessment = Assessment.Excellent,
				ProtectionDate = DateTime.Now,
				ProtocolNumber = "2015-231000-28",
				RegistrationNumber = "76 004",
				RegistrationDate = DateTime.Now,
				Group = group,
				AssessmentByDisciplines = new[] {
					new AssessmentByDiscipline {
						NameOfDiscipline = "Английский язык",
						Assessment = Assessment.Good
					},
					new AssessmentByDiscipline {
						NameOfDiscipline = "Архитектура ЭВМ",
						Assessment = Assessment.Excellent
					},
					new AssessmentByDiscipline {
						NameOfDiscipline = "Физика",
						Assessment = Assessment.Credited
					},
					new AssessmentByDiscipline {
						NameOfDiscipline = "Вычислительная математика",
						Assessment = Assessment.Credited
					},
					new AssessmentByDiscipline {
						NameOfDiscipline = "Инженерная графика",
						Assessment = Assessment.Excellent
					}
				}
			});
		}
	}
}