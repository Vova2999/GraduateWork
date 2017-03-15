using System;
using System.Linq;
using System.Net;
using GraduateWork.Common.Exceptions;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Client.Client {
	public class BaseHttpClient {
		protected static bool TrySendRequestWithoutReturn(string methodName, int timeoutMs = 5000) {
			return TrySendRequest(() => {
				SendRequest<bool>(methodName, timeoutMs);
				return true;
			},
				() => false);
		}
		protected static bool TrySendRequestWithoutReturn(string methodName, byte[] requestBody, int timeoutMs = 5000) {
			return TrySendRequest(() => {
				SendRequest<bool>(methodName, requestBody, timeoutMs);
				return true;
			},
				() => false);
		}
		protected static TKey TrySendRequestWithReturn<TKey>(string methodName, Func<TKey> actionWhenException, int timeoutMs = 5000) {
			return TrySendRequest(() => SendRequest<TKey>(methodName, timeoutMs), actionWhenException);
		}
		protected static TKey TrySendRequestWithReturn<TKey>(string methodName, byte[] requestBody, Func<TKey> actionWhenException, int timeoutMs = 5000) {
			return TrySendRequest(() => SendRequest<TKey>(methodName, requestBody, timeoutMs), actionWhenException);
		}
		private static TKey TrySendRequest<TKey>(Func<TKey> primaryAction, Func<TKey> actionWhenException) {
			try {
				return primaryAction();
			}
			catch (Exception) {
				return actionWhenException();
			}
		}

		private static TKey SendRequest<TKey>(string methodName, int timeoutMs = 5000) {
			var webRequest = CreateGetRequest(methodName, timeoutMs);
			return SendRequest<TKey>(webRequest);
		}
		private static TKey SendRequest<TKey>(string methodName, byte[] requestBody, int timeoutMs = 5000) {
			var webRequest = CreatePostRequest(methodName, requestBody, timeoutMs);
			return SendRequest<TKey>(webRequest);
		}

		private static HttpWebRequest CreateGetRequest(string methodName, int timeoutMs) {
			var webRequest = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1/{methodName}");
			webRequest.Timeout = timeoutMs;
			webRequest.Method = "GET";

			return webRequest;
		}
		private static HttpWebRequest CreatePostRequest(string methodName, byte[] requestBody, int timeoutMs) {
			var webRequest = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1/{methodName}");
			webRequest.Timeout = timeoutMs;
			webRequest.Method = "POST";

			webRequest.ContentLength = requestBody.Length;
			using (var stream = webRequest.GetRequestStream())
				stream.Write(requestBody, 0, requestBody.Length);

			return webRequest;
		}

		private static TKey SendRequest<TKey>(HttpWebRequest webRequest) {
			var webResponse = (HttpWebResponse)webRequest.GetResponse();
			if (webResponse.StatusCode != HttpStatusCode.OK)
				throw new HttpException(webResponse.StatusCode, webResponse.GetResponseStream().ReadAndDispose().FromJson<string>());

			return GetAnswer<TKey>(webResponse);
		}
		private static TKey GetAnswer<TKey>(HttpWebResponse webResponse) {
			var outputBytes = webResponse.GetResponseStream().ReadAndDispose();
			return outputBytes.Any() ? outputBytes.FromJson<TKey>() : default(TKey);
		}
	}
}