using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Common.Reports {
	// ReSharper disable UnusedMember.Global

	public interface IReportsCreator {
		FileWithContent CreateAcadem(StudentExtendedProxy student);
		FileWithContent CreateDiploma(StudentExtendedProxy student);
		FileWithContent CreateDiplomaSupplement(StudentExtendedProxy student);
	}
}