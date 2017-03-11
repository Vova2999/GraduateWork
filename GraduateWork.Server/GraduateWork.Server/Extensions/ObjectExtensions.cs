using System.Text;
using Newtonsoft.Json;

namespace GraduateWork.Server.Extensions {
	public static class ObjectExtensions {
		public static byte[] ToJson(this object obj) {
			return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
		}
	}
}