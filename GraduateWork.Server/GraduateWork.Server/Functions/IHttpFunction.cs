using System.Net;
using GraduateWork.Server.AdditionalObjects;

namespace GraduateWork.Server.Functions {
	public interface IHttpFunction {
		string NameOfCalledMethod { get; }
		void Execute(HttpListenerContext context, NameValues parameters);
	}
}