using System.Net;

namespace GraduateWork.Server.Functions {
	public interface IHttpFunction {
		string NameOfCalledMethod { get; }
		void RunMethod(HttpListenerContext context);
	}
}