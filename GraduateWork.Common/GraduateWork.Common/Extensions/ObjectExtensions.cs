using GraduateWork.Common.Serializers;

namespace GraduateWork.Common.Extensions {
	// ReSharper disable UnusedMember.Global

	public static class ObjectExtensions {
		public static byte[] ToJson<TKey>(this TKey obj) {
			return JsonSerializer.Serializing(obj);
		}

		public static byte[] ToXml<TKey>(this TKey obj) {
			return XmlSerializer.Serializing(obj);
		}
	}
}