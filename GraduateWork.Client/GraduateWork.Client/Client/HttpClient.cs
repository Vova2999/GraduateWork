using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public class HttpClient : BaseHttpClient, IHttpClient {
		public bool Ping() {
			return TrySendRequest("Ping", () => false);
		}

		public GroupProxy[] GetAllGroups() {
			return TrySendRequest("GetAllGroups", () => new GroupProxy[0]);
		}

		public DisciplineProxy[] GetAllDisciplines() {
			return TrySendRequest("GetAllDisciplines", () => new DisciplineProxy[0]);
		}

		public StudentProxy[] GetAllStudents() {
			return TrySendRequest("GetAllStudents", () => new StudentProxy[0]);
		}
	}
}