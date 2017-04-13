using System;
using System.IO;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Common {
	// ReSharper disable UnusedMember.Global

	public abstract class FileSettings<TSettings> where TSettings : FileSettings<TSettings>, new() {
		protected abstract string SettingsFileName { get; }

		public static TSettings ReadSettings() {
			var settingsFileName = new TSettings().SettingsFileName;
			try {
				return File.Exists(settingsFileName)
					? File.ReadAllBytes(settingsFileName).FromXml<TSettings>()
					: new TSettings();
			}
			catch (Exception) {
				return new TSettings();
			}
		}
		public void WriteSettings() {
			File.WriteAllBytes(SettingsFileName, this.ToXml());
		}
	}
}