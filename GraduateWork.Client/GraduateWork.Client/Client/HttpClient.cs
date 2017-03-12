using System.Collections.Generic;
using System.Net;
using GraduateWork.Client.Extensions;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.Client {
	public class HttpClient : IHttpClient {
		public bool Ping() {
			return SendRequest(RequestType.Get, "Ping").StatusCode == HttpStatusCode.OK;
		}

		public IEnumerable<GroupProxy> GetAllGroups() {
			return SendRequest(RequestType.Get, "GetAllGroups").GetResponseBytes().FromJson<IEnumerable<GroupProxy>>();
		}

		public IEnumerable<DisciplineProxy> GetAllDisciplines() {
			return SendRequest(RequestType.Get, "GetAllDisciplines").GetResponseBytes().FromJson<IEnumerable<DisciplineProxy>>();
		}

		public IEnumerable<StudentProxy> GetAllStudents() {
			return SendRequest(RequestType.Get, "GetAllStudents").GetResponseBytes().FromJson<IEnumerable<StudentProxy>>();
		}

		private HttpWebResponse SendRequest(RequestType requestType, string methodName, byte[] requestBody = null, int timeoutMs = 5000) {
			var webRequest = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1/{methodName}");
			webRequest.Timeout = timeoutMs;
			webRequest.Method = requestType.ToString();

			if (requestType != RequestType.Post || requestBody == null)
				return (HttpWebResponse)webRequest.GetResponse();

			webRequest.ContentLength = requestBody.Length;
			using (var stream = webRequest.GetRequestStream())
				stream.Write(requestBody, 0, requestBody.Length);

			return (HttpWebResponse)webRequest.GetResponse();
		}
	}
}