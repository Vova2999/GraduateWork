﻿using System;
using System.Net;
using GraduateWork.Common.Extensions;

namespace GraduateWork.Server.Extensions {
	public static class HttpListenerResponseExtensions {
		public static void Respond(this HttpListenerResponse response, HttpStatusCode statusCode, byte[] bytes) {
			try {
				response.StatusCode = (int)statusCode;
				response.OutputStream.WriteAndDispose(bytes);
			}
			catch (Exception) {
				// ignored
			}
		}
	}
}