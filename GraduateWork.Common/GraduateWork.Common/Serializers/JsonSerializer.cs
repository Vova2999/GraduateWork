using Newtonsoft.Json;

namespace GraduateWork.Common.Serializers {
	internal static class JsonSerializer {
		public static byte[] Serializing(object obj) {
			return GlobalSettings.Encoding.GetBytes(JsonConvert.SerializeObject(obj));
		}

		public static TKey Deserializing<TKey>(byte[] bytes) {
			return JsonConvert.DeserializeObject<TKey>(GlobalSettings.Encoding.GetString(bytes));
		}
	}
}