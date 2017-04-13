using GraduateWork.Common;

namespace GraduateWork.Server {
	public class ServerSettings : FileSettings<ServerSettings> {
		protected override string SettingsFileName => "GraduateWork.Server.Settings.xml";

		public string ServerAddress { get; set; }
	}
}