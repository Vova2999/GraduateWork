using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public class HttpClient : BaseHttpClient, IHttpClient {
		public void Ping() {
			SendRequest("Ping");
		}

		public GroupProxy[] GetAllGroups() {
			return SendRequest<GroupProxy[]>("GetAllGroups");
		}
		public DisciplineProxy[] GetAllDisciplines() {
			return SendRequest<DisciplineProxy[]>("GetAllDisciplines");
		}
		public StudentProxy[] GetAllStudents() {
			return SendRequest<StudentProxy[]>("GetAllStudents");
		}

		public void AddGroup(GroupProxy group) {
			SendRequest("AddGroup", group.ToJson());
		}
		public void EditGroup(GroupProxy oldGroup, GroupProxy newGroup) {
			SendRequest("EditGroup", Tuple.Create(oldGroup, newGroup).ToJson());
		}
		public void DeleteGroup(GroupProxy group) {
			SendRequest("DeleteGroup", group.ToJson());
		}

		public void AddDiscipline(DisciplineProxy discipline) {
			SendRequest("AddDiscipline", discipline.ToJson());
		}
		public void EditDiscipline(DisciplineProxy oldDiscipline, DisciplineProxy newDiscipline) {
			SendRequest("EditDiscipline", Tuple.Create(oldDiscipline, newDiscipline).ToJson());
		}
		public void DeleteDiscipline(DisciplineProxy discipline) {
			SendRequest("DeleteDiscipline", discipline.ToJson());
		}

		public void AddStudent(StudentProxy student) {
			SendRequest("AddStudent", student.ToJson());
		}
		public void EditStudent(StudentProxy oldStudent, StudentProxy newStudent) {
			SendRequest("EditStudent", Tuple.Create(oldStudent, newStudent).ToJson());
		}
		public void DeleteStudent(StudentProxy student) {
			SendRequest("DeleteStudent", student.ToJson());
		}
	}
}