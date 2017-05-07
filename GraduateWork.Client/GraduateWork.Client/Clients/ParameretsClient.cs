using System;
using System.Collections.Generic;
using GraduateWork.Common.Http;

namespace GraduateWork.Client.Clients {
	public class ParameretsClient : BaseHttpClient {
		private readonly HttpClientParameters httpClientParameters;

		public ParameretsClient(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
			this.httpClientParameters = httpClientParameters;
		}

		public void SetServerAddress(string serverAddress) {
			serverAddress = new UriBuilder(serverAddress).Uri.ToString();

			new ParameretsClient(new HttpClientParameters { ServerAddress = serverAddress }).SendRequest("Ping");
			httpClientParameters.ServerAddress = serverAddress;
		}
		public void SetLoginAndPassword(string login, string password) {
			var parameters = new Dictionary<string, string> {
				[HttpParameters.Login] = login,
				[HttpParameters.Password] = password
			};

			SendRequest("CheckUserIsExist", parameters);
			httpClientParameters.Login = login;
			httpClientParameters.Password = password;
		}
	}
}