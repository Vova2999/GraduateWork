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
	}
}