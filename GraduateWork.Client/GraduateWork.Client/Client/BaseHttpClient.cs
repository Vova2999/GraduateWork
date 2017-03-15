using System.Linq;
using System.Net;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Client.Client {
	public class BaseHttpClient {
		protected static void SendRequest(string methodName, byte[] requestBody = null, int timeoutMs = 5000) {
			var webRequest = CreateWebRequest(methodName, requestBody, timeoutMs);
			SendRequest(webRequest);
		}
		protected static TKey SendRequest<TKey>(string methodName, byte[] requestBody = null, int timeoutMs = 5000) {
			var webRequest = CreateWebRequest(methodName, requestBody, timeoutMs);
			return GetAnswer<TKey>(SendRequest(webRequest));
		}

		private static HttpWebRequest CreateWebRequest(string methodName, byte[] requestBody, int timeoutMs) {
			var webRequest = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1/{methodName}");
			webRequest.Timeout = timeoutMs;

			return requestBody == null
				? CreateGetRequest(webRequest)
				: CreatePostRequest(webRequest, requestBody);
		}
		private static HttpWebRequest CreateGetRequest(HttpWebRequest webRequest) {
			webRequest.Method = "GET";
			return webRequest;
		}
		private static HttpWebRequest CreatePostRequest(HttpWebRequest webRequest, byte[] requestBody) {
			webRequest.Method = "POST";
			webRequest.ContentLength = requestBody.Length;
			using (var stream = webRequest.GetRequestStream())
				stream.Write(requestBody, 0, requestBody.Length);

			return webRequest;
		}

		private static HttpWebResponse SendRequest(HttpWebRequest webRequest) {
			try {
				return (HttpWebResponse)webRequest.GetResponse();
			}
			catch (WebException exception) {
				throw new WebException($"{exception.Message}\n{exception.Response.GetResponseStream().ReadAndDispose().FromJson<string>()}");
			}
		}
		private static TKey GetAnswer<TKey>(HttpWebResponse webResponse) {
			var outputBytes = webResponse.GetResponseStream().ReadAndDispose();
			return outputBytes.Any() ? outputBytes.FromJson<TKey>() : default(TKey);
		}
	}
}