using GraduateWork.Common;

namespace GraduateWork.Server.UI {
	public class ServerUiSettings : FileSettings<ServerUiSettings> {
		protected override string SettingsFileName => "GraduateWork.Server.UI.Settings.xml";

		public string UserLogin { get; set; }
		public string UserPassword { get; set; }
		public bool SaveLoginAndPassword { get; set; }
	}
}