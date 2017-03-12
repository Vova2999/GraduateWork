using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public interface IHttpClient {
		bool Ping();
		StudentProxy[] GetAllStudents();
	}
}