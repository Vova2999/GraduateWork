using System;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public class HttpClient : BaseHttpClient, IHttpClient {
		public bool Ping() {
			return TrySendRequestWithoutReturn("Ping");
		}

		public GroupProxy[] GetAllGroups() {
			return TrySendRequestWithReturn("GetAllGroups", () => new GroupProxy[0]);
		}
		public DisciplineProxy[] GetAllDisciplines() {
			return TrySendRequestWithReturn("GetAllDisciplines", () => new DisciplineProxy[0]);
		}
		public StudentProxy[] GetAllStudents() {
			return TrySendRequestWithReturn("GetAllStudents", () => new StudentProxy[0]);
		}

		public bool AddGroup(GroupProxy group) {
			return TrySendRequestWithoutReturn("AddGroup", group.ToJson());
		}
		public bool EditGroup(GroupProxy oldGroup, GroupProxy newGroup) {
			return TrySendRequestWithoutReturn("EditGroup", Tuple.Create(oldGroup, newGroup).ToJson());
		}
		public bool DeleteGroup(GroupProxy group) {
			return TrySendRequestWithoutReturn("DeleteGroup", group.ToJson());
		}
	}
}