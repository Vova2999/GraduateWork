using System.IO;
using System.Net;
using System.Text;

namespace GraduateWork.Client.Extensions {
	public static class HttpWebResponseExtensions {
		public static byte[] GetResponseBytes(this HttpWebResponse httpWebResponse) {
			var responseStream = httpWebResponse.GetResponseStream();
			if (responseStream == null)
				return null;

			using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
				return Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
		}
	}
}