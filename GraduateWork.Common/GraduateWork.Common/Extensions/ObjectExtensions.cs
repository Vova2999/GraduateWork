using Newtonsoft.Json;

namespace GraduateWork.Common.Extensions {
	// ReSharper disable UnusedMember.Global

	public static class ObjectExtensions {
		public static byte[] ToJson(this object obj) {
			return GlobalSettings.Encoding.GetBytes(JsonConvert.SerializeObject(obj));
		}
	}
}