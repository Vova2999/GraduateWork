using System.IO;

namespace GraduateWork.Common.Extensions {
	public static class StreamExtensions {
		public static void WriteAndDispose(this Stream stream, byte[] bytes) {
			using (stream)
				stream.Write(bytes, 0, bytes?.Length ?? 0);
		}

		public static byte[] ReadAndDispose(this Stream stream) {
			using (var streamReader = new StreamReader(stream))
				return GlobalSettings.Encoding.GetBytes(streamReader.ReadToEnd());
		}
	}
}