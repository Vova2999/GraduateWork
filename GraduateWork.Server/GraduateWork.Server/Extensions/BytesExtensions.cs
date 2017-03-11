using System.Text;
using Newtonsoft.Json;

namespace GraduateWork.Server.Extensions {
	public static class BytesExtensions {
		public static TKey FromJson<TKey>(this byte[] bytes) {
			return JsonConvert.DeserializeObject<TKey>(Encoding.UTF8.GetString(bytes));
		}
	}
}