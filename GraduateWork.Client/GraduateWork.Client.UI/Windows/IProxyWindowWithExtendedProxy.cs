namespace GraduateWork.Client.UI.Windows {
	public interface IProxyWindowWithExtendedProxy<out TExtendedProxy> : IProxyWindow {
		TExtendedProxy ExtendedProxy { get; }
	}
}