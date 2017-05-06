using System;
using System.Collections.Concurrent;
using GraduateWork.Client.Clients;
using GraduateWork.Client.Clients.Database.Editors;
using GraduateWork.Client.Clients.Database.Readers;
using GraduateWork.Client.Clients.Reports;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Reports;

namespace GraduateWork.Client {
	public class HttpClientProvider {
		private readonly ConcurrentDictionary<string, BaseHttpClient> hashedClients;
		private readonly HttpClientParameters httpClientParameters;

		public HttpClientProvider(string serverAddress, string login, string password) {
			hashedClients = new ConcurrentDictionary<string, BaseHttpClient>();
			httpClientParameters = new HttpClientParameters {
				ServerAddress = serverAddress,
				Login = login,
				Password = password
			};
		}

		public ParameretsClient GetParameretsClient() {
			return GetClient("ParameretsClient", () => new ParameretsClient(httpClientParameters));
		}

		public IReportsCreator GetReportsCreator() {
			return GetClient("ReportsCreator", () => new ReportsCreator(httpClientParameters));
		}

		public IDatabaseDisciplineEditor GetDatabaseDisciplineEditor() {
			return GetClient("DatabaseDisciplineEditor", () => new DatabaseDisciplineEditor(httpClientParameters));
		}
		public IDatabaseGroupEditor GetDatabaseGroupEditor() {
			return GetClient("DatabaseGroupEditor", () => new DatabaseGroupEditor(httpClientParameters));
		}
		public IDatabaseStudentEditor GetDatabaseStudentEditor() {
			return GetClient("DatabaseStudentEditor", () => new DatabaseStudentEditor(httpClientParameters));
		}
		public IDatabaseUserEditor GetDatabaseUserEditor() {
			return GetClient("DatabaseUserEditor", () => new DatabaseUserEditor(httpClientParameters));
		}

		public IDatabaseAssessmentByDisciplinesReader GetDatabaseAssessmentByDisciplinesReader() {
			return GetClient("DatabaseAssessmentByDisciplinesReader", () => new DatabaseAssessmentByDisciplinesReader(httpClientParameters));
		}
		public IDatabaseDisciplineReader GetDatabaseDisciplineReader() {
			return GetClient("DatabaseDisciplineReader", () => new DatabaseDisciplineReader(httpClientParameters));
		}
		public IDatabaseGroupReader GetDatabaseGroupReader() {
			return GetClient("DatabaseGroupReader", () => new DatabaseGroupReader(httpClientParameters));
		}
		public IDatabaseStudentReader GetDatabaseStudentReader() {
			return GetClient("DatabaseStudentReader", () => new DatabaseStudentReader(httpClientParameters));
		}
		public IDatabaseUserReader GetDatabaseUserReader() {
			return GetClient("DatabaseUserReader", () => new DatabaseUserReader(httpClientParameters));
		}

		private TClient GetClient<TClient>(string clientName, Func<TClient> createClient) where TClient : BaseHttpClient {
			return (TClient)hashedClients.GetOrAdd(clientName, name => createClient());
		}
	}
}