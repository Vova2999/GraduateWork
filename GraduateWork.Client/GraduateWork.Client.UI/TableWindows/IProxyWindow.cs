using System.Collections.Generic;

namespace GraduateWork.Client.UI.TableWindows {
	public interface IProxyWindow {
		bool IsReadOnly { get; }
		IEnumerable<string> GetErrors();
		void WriteProxy();
	}
}