using System;
using System.IO;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Common {
	// ReSharper disable UnusedMember.Global

	public abstract class ConfigurationFile<TSettings> where TSettings : ConfigurationFile<TSettings>, new() {
		protected abstract string ConfigurationFileName { get; }

		public static TSettings ReadConfiguration() {
			var settingsFileName = new TSettings().ConfigurationFileName;
			try {
				return File.Exists(settingsFileName)
					? File.ReadAllBytes(settingsFileName).FromXml<TSettings>()
					: new TSettings();
			}
			catch (Exception) {
				return new TSettings();
			}
		}
		public void WriteConfiguration() {
			File.WriteAllBytes(ConfigurationFileName, this.ToXml());
		}
	}
}