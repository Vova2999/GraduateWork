﻿using System;
using GraduateWork.Common.Tables.Attributes;

namespace GraduateWork.Common.Tables.Proxies.Baseds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable MemberCanBeProtected.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable UnusedMember.Global

	public class UserBasedProxy {
		[HeaderColumn("Логин")]
		public string Login { get; set; }

		public override bool Equals(object obj) {
			var that = (UserBasedProxy)obj;
			return that != null &&
				string.Equals(Login, that.Login, StringComparison.InvariantCultureIgnoreCase);
		}
		public override int GetHashCode() {
			return Login?.GetHashCode() ?? 0;
		}

		public UserBasedProxy GetBasedClone() {
			return GetClone<UserBasedProxy>();
		}
		public TProxy GetClone<TProxy>() where TProxy : UserBasedProxy, new() {
			return new TProxy {
				Login = Login
			};
		}
	}
}