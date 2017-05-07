using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies.Baseds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable MemberCanBeProtected.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode

	public class StudentBasedProxy {
		[HeaderColumn("Имя")]
		public string FirstName { get; set; }

		[HeaderColumn("Фамилия")]
		public string SecondName { get; set; }

		[HeaderColumn("Отчество")]
		public string ThirdName { get; set; }

		[HeaderColumn("Дата рождения")]
		public DateTime DateOfBirth { get; set; }

		public override bool Equals(object obj) {
			var that = obj as StudentBasedProxy;
			return that != null &&
				string.Equals(FirstName, that.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
				string.Equals(SecondName, that.SecondName, StringComparison.InvariantCultureIgnoreCase) &&
				string.Equals(ThirdName, that.ThirdName, StringComparison.InvariantCultureIgnoreCase) &&
				Equals(DateOfBirth, that.DateOfBirth);
		}
		public override int GetHashCode() {
			return (FirstName?.GetHashCode() ?? 0 * 397) ^ ((SecondName?.GetHashCode() ?? 0) * 397) ^ ((ThirdName?.GetHashCode() ?? 0) * 397) ^ DateOfBirth.GetHashCode();
		}

		public StudentBasedProxy GetBasedClone() {
			return GetClone<StudentBasedProxy>();
		}
		public TProxy GetClone<TProxy>() where TProxy : StudentBasedProxy, new() {
			return new TProxy {
				FirstName = FirstName,
				SecondName = SecondName,
				ThirdName = ThirdName,
				DateOfBirth = DateOfBirth
			};
		}
	}
}