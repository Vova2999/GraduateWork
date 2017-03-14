using System.IO;

namespace GraduateWork.Server.Extensions {
	public static class StreamExtensions {
		public static void WriteAndDispose(this Stream stream, byte[] bytes) {
			using (stream)
				stream.Write(bytes, 0, bytes?.Length ?? 0);
		}
	}
}