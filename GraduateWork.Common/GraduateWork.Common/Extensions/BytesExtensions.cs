using Newtonsoft.Json;

namespace GraduateWork.Common.Extensions {
	public static class BytesExtensions {
		public static TKey FromJson<TKey>(this byte[] bytes) {
			return JsonConvert.DeserializeObject<TKey>(GlobalSettings.Encoding.GetString(bytes));
		}
	}
}