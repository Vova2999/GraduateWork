using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Server.Common.Reports {
	public interface IReportsCreator {
		FileWithContent CreateAcadem(StudentExtendedProxy student);
		FileWithContent CreateDiploma(StudentExtendedProxy student);
		FileWithContent CreateDiplomaSupplement(StudentExtendedProxy student);
	}
}