using System.Collections.Generic;
using System.Linq;
using System.Net;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Client.Client {
	// ReSharper disable UnusedMember.Global

	public class BaseHttpClient {
		protected string ServerAddress;

		protected void SendRequest(string methodName, byte[] requestBody = null, int timeoutMs = 2000) {
			SendRequest(methodName, new Dictionary<string, string>(), requestBody, timeoutMs);
		}
		protected void SendRequest(string methodName, Dictionary<string, string> parameters, byte[] requestBody = null, int timeoutMs = 2000) {
			var webRequest = CreateWebRequest(methodName, parameters, requestBody, timeoutMs);
			SendRequest(webRequest);
		}
		protected TKey SendRequest<TKey>(string methodName, byte[] requestBody = null, int timeoutMs = 2000) {
			return SendRequest<TKey>(methodName, new Dictionary<string, string>(), requestBody, timeoutMs);
		}
		protected TKey SendRequest<TKey>(string methodName, Dictionary<string, string> parameters, byte[] requestBody = null, int timeoutMs = 2000) {
			var webRequest = CreateWebRequest(methodName, parameters, requestBody, timeoutMs);
			return GetAnswer<TKey>(SendRequest(webRequest));
		}

		private HttpWebRequest CreateWebRequest(string methodName, Dictionary<string, string> parameters, byte[] requestBody, int timeoutMs) {
			var webRequest = (HttpWebRequest)WebRequest.Create(ServerAddress + CreateRequestUri(methodName, parameters));
			webRequest.Timeout = timeoutMs;

			return requestBody == null
				? CreateGetRequest(webRequest)
				: CreatePostRequest(webRequest, requestBody);
		}
		private string CreateRequestUri(string methodName, Dictionary<string, string> parameters) {
			return parameters.Any() ? $"{methodName}?{string.Join("&", parameters.Select(parameter => $"{parameter.Key}={parameter.Value}"))}" : methodName;
		}
		private HttpWebRequest CreateGetRequest(HttpWebRequest webRequest) {
			webRequest.Method = "GET";
			return webRequest;
		}
		private HttpWebRequest CreatePostRequest(HttpWebRequest webRequest, byte[] requestBody) {
			webRequest.Method = "POST";
			webRequest.ContentLength = requestBody.Length;
			webRequest.GetRequestStream().WriteAndDispose(requestBody);

			return webRequest;
		}

		private HttpWebResponse SendRequest(HttpWebRequest webRequest) {
			try {
				return (HttpWebResponse)webRequest.GetResponse();
			}
			catch (WebException exception) {
				throw new WebException(string.Join("\n",
					new[] {
						exception.Message,
						exception.Response?.GetResponseStream().ReadAndDispose().FromJson<string>()
					}.Where(message => !string.IsNullOrEmpty(message))));
			}
		}
		private TKey GetAnswer<TKey>(HttpWebResponse webResponse) {
			var outputBytes = webResponse.GetResponseStream().ReadAndDispose();
			return outputBytes.Any() ? outputBytes.FromJson<TKey>() : default(TKey);
		}
	}
}