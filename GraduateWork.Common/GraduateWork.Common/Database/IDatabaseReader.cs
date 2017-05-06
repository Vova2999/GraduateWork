namespace GraduateWork.Common.Database {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseReader<TBasedProxy, out TExtendedProxy> {
		TBasedProxy[] GetAllBasedProies();
		TExtendedProxy GetExtendedProxy(TBasedProxy basedProxy);
	}
}