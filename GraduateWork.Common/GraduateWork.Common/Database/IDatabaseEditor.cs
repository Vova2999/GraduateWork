namespace GraduateWork.Common.Database {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseEditor<in TBasedProxy, in TExtendedProxy> {
		void Add(TExtendedProxy extendedProxy);
		void Edit(TExtendedProxy oldExtendedProxy, TExtendedProxy newExtendedProxy);
		void Delete(TBasedProxy basedProxy);
	}
}