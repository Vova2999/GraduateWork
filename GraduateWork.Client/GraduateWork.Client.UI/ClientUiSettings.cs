namespace GraduateWork.Client.UI {
	public class ClientUiSettings {
		public const string FileName = "GraduateWork.Client.UI.Settings.xml";

		public string ServerAddress { get; set; }
		public string UserLogin { get; set; }
		public string UserPassword { get; set; }
		public bool SaveLoginAndPassword { get; set; }
	}
}