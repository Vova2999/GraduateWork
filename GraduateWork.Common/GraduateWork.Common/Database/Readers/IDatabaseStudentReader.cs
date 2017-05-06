using System;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseStudentReader : IDatabaseReader<StudentBasedProxy, StudentExtendedProxy> {
		StudentBasedProxy[] GetStudentsWithUsingFilters(string firstName, string secondName, string thirdName, DateTime? dateOfBirth);
	}
}