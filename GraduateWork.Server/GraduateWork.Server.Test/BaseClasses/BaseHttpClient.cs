﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Server.Test.BaseClasses {
	// ReSharper disable UnusedMember.Global

	public abstract class BaseHttpClient {
		protected static void SendRequest(string methodName, byte[] requestBody = null, int timeoutMs = 2000) {
			SendRequest(methodName, new Dictionary<string, string>(), requestBody, timeoutMs);
		}
		protected static void SendRequest(string methodName, Dictionary<string, string> parameters, byte[] requestBody = null, int timeoutMs = 2000) {
			var webRequest = CreateWebRequest(methodName, parameters, requestBody, timeoutMs);
			SendRequest(webRequest);
		}
		protected static TKey SendRequest<TKey>(string methodName, byte[] requestBody = null, int timeoutMs = 2000) {
			return SendRequest<TKey>(methodName, new Dictionary<string, string>(), requestBody, timeoutMs);
		}
		protected static TKey SendRequest<TKey>(string methodName, Dictionary<string, string> parameters, byte[] requestBody = null, int timeoutMs = 2000) {
			var webRequest = CreateWebRequest(methodName, parameters, requestBody, timeoutMs);
			return GetAnswer<TKey>(SendRequest(webRequest));
		}

		private static HttpWebRequest CreateWebRequest(string methodName, Dictionary<string, string> parameters, byte[] requestBody, int timeoutMs) {
			var webRequest = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1/{CreateRequestUri(methodName, parameters)}");
			webRequest.Timeout = timeoutMs;

			return requestBody == null
				? CreateGetRequest(webRequest)
				: CreatePostRequest(webRequest, requestBody);
		}
		private static string CreateRequestUri(string methodName, Dictionary<string, string> parameters) {
			return !parameters.Any() ? methodName : $"{methodName}?{string.Join("&", parameters.Select(parameter => $"{parameter.Key}={parameter.Value}"))}";
		}
		private static HttpWebRequest CreateGetRequest(HttpWebRequest webRequest) {
			webRequest.Method = "GET";
			return webRequest;
		}
		private static HttpWebRequest CreatePostRequest(HttpWebRequest webRequest, byte[] requestBody) {
			webRequest.Method = "POST";
			webRequest.ContentLength = requestBody.Length;
			webRequest.GetRequestStream().WriteAndDispose(requestBody);

			return webRequest;
		}

		private static HttpWebResponse SendRequest(HttpWebRequest webRequest) {
			return (HttpWebResponse)webRequest.GetResponse();
		}
		private static TKey GetAnswer<TKey>(HttpWebResponse webResponse) {
			var outputBytes = webResponse.GetResponseStream().ReadAndDispose();
			return outputBytes.Any() ? outputBytes.FromJson<TKey>() : default(TKey);
		}
	}
}