using System;
using System.Net;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Server.Extensions {
	public static class HttpListenerContextExtensions {
		public static void SendErrorResponse(this HttpListenerContext context, HttpStatusCode statusCode, string message) {
			try {
				context.Response.StatusCode = (int)statusCode;
				context.Response.OutputStream.WriteAndDispose(message.ToJson());
			}
			catch (Exception) {
				// ignored
			}
		}
	}
}