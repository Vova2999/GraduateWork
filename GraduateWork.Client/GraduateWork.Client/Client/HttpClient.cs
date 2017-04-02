using System;
using System.Collections.Generic;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.Client {
	public class HttpClient : BaseHttpClient, IHttpClient {
		public string Login { get; set; }
		public string Password { get; set; }
		public new string ServerAddress {
			get { return base.ServerAddress; }
			set { base.ServerAddress = new UriBuilder(value).Uri.ToString(); }
		}

		public void Ping() {
			SendRequest("Ping");
		}
		public void CheckUserIsExist(string login, string password) {
			SendRequest("CheckUserIsExist",
				new Dictionary<string, string> {
					{ HttpParameters.Login, login },
					{ HttpParameters.Password, password }
				});
		}

		GroupBasedProxy[] IHttpClient.GetAllGroups() {
			return SendRequest<GroupBasedProxy[]>("GetAllGroups", GetDefaultParameters());
		}
		DisciplineBasedProxy[] IHttpClient.GetAllDisciplines() {
			return SendRequest<DisciplineBasedProxy[]>("GetAllDisciplines", GetDefaultParameters());
		}
		StudentBasedProxy[] IHttpClient.GetAllStudents() {
			return SendRequest<StudentBasedProxy[]>("GetAllStudents", GetDefaultParameters());
		}
		public UserProxy[] GetAllUsers() {
			return SendRequest<UserProxy[]>("GetAllUsers", GetDefaultParameters());
		}

		public void AddGroup(GroupExtendedProxy group) {
			SendRequest("AddGroup", GetDefaultParameters(), group.ToJson());
		}
		public void EditGroup(GroupExtendedProxy oldGroup, GroupExtendedProxy newGroup) {
			SendRequest("EditGroup", GetDefaultParameters(), Tuple.Create(oldGroup, newGroup).ToJson());
		}
		public void DeleteGroup(GroupExtendedProxy group) {
			SendRequest("DeleteGroup", GetDefaultParameters(), group.ToJson());
		}

		public void AddDiscipline(DisciplineExtendedProxy discipline) {
			SendRequest("AddDiscipline", GetDefaultParameters(), discipline.ToJson());
		}
		public void EditDiscipline(DisciplineExtendedProxy oldDiscipline, DisciplineExtendedProxy newDiscipline) {
			SendRequest("EditDiscipline", GetDefaultParameters(), Tuple.Create(oldDiscipline, newDiscipline).ToJson());
		}
		public void DeleteDiscipline(DisciplineExtendedProxy discipline) {
			SendRequest("DeleteDiscipline", GetDefaultParameters(), discipline.ToJson());
		}

		public void AddStudent(StudentExtendedProxy student) {
			SendRequest("AddStudent", GetDefaultParameters(), student.ToJson());
		}
		public void EditStudent(StudentExtendedProxy oldStudent, StudentExtendedProxy newStudent) {
			SendRequest("EditStudent", GetDefaultParameters(), Tuple.Create(oldStudent, newStudent).ToJson());
		}
		public void DeleteStudent(StudentExtendedProxy student) {
			SendRequest("DeleteStudent", GetDefaultParameters(), student.ToJson());
		}

		public void AddUser(UserProxy user) {
			SendRequest("AddUser", GetDefaultParameters(), user.ToJson());
		}
		public void EditUser(UserProxy oldUser, UserProxy newUser) {
			SendRequest("EditUser", GetDefaultParameters(), Tuple.Create(oldUser, newUser).ToJson());
		}
		public void DeleteUser(UserProxy user) {
			SendRequest("DeleteUser", GetDefaultParameters(), user.ToJson());
		}

		private Dictionary<string, string> GetDefaultParameters() {
			return new Dictionary<string, string> {
				{ HttpParameters.Login, Login },
				{ HttpParameters.Password, Password }
			};
		}
	}
}