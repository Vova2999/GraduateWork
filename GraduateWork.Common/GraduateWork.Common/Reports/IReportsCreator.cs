using GraduateWork.Common.Tables.Proxies.Baseds;

namespace GraduateWork.Common.Reports {
	// ReSharper disable UnusedMember.Global

	public interface IReportsCreator {
		FileWithContent CreateAcadem(StudentBasedProxy student);
		FileWithContent CreateDiploma(StudentBasedProxy student);
		FileWithContent CreateDiplomaSupplement(StudentBasedProxy student);
	}
}