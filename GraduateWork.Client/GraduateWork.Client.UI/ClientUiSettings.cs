using GraduateWork.Common;

namespace GraduateWork.Client.UI {
	public class ClientUiSettings : FileSettings<ClientUiSettings> {
		protected override string SettingsFileName => "GraduateWork.Client.UI.Settings.xml";

		public string ServerAddress { get; set; }
		public string UserLogin { get; set; }
		public string UserPassword { get; set; }
		public bool SaveLoginAndPassword { get; set; }
	}
}