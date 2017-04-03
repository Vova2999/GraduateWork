using System;
using System.IO;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Common {
	// ReSharper disable UnusedMember.Global

	public static class FileSettings {
		public static TSettings ReadSettings<TSettings>(string settingsFileName) where TSettings : new() {
			try {
				return File.Exists(settingsFileName)
					? File.ReadAllBytes(settingsFileName).FromXml<TSettings>()
					: new TSettings();
			}
			catch (Exception) {
				return new TSettings();
			}
		}
		public static void WriteSettings<TSettings>(TSettings settings, string settingsFileName) {
			File.WriteAllBytes(settingsFileName, settings.ToXml());
		}
	}
}