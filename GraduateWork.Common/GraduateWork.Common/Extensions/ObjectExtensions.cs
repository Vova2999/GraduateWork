using Newtonsoft.Json;

namespace GraduateWork.Common.Extensions {
	public static class ObjectExtensions {
		public static byte[] ToJson(this object obj) {
			return GlobalSettings.Encoding.GetBytes(JsonConvert.SerializeObject(obj));
		}
	}
}