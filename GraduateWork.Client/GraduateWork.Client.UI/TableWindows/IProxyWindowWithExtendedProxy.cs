namespace GraduateWork.Client.UI.TableWindows {
	public interface IProxyWindowWithExtendedProxy<out TExtendedProxy> : IProxyWindow {
		TExtendedProxy ExtendedProxy { get; }
	}
}