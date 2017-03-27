using GraduateWork.Common.Reports;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Server.Common.Reports {
	public interface IReportsCreator {
		FileWithContent CreateAcadem(StudentProxy student);
		FileWithContent CreateDiploma(StudentProxy student);
		FileWithContent CreateDiplomaSupplement(StudentProxy student);
	}
}