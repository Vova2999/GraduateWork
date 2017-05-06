using System.Collections.Generic;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Database.Tables;

namespace GraduateWork.Server.Database.Models.Editors {
	// ReSharper disable ClassNeverInstantiated.Global

	public class DatabaseGroupEditor : DatabaseEditor, IDatabaseGroupEditor {
		public DatabaseGroupEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(GroupExtendedProxy extendedProxy) {
			ModelDatabase.Groups.Add(new Group {
				GroupName = extendedProxy.GroupName,
				SpecialtyName = extendedProxy.SpecialtyName,
				SpecialtyNumber = extendedProxy.SpecialtyNumber,
				FacultyName = extendedProxy.FacultyName,
				Students = new List<Student>(),
				Disciplines = new List<Discipline>()
			});

			ModelDatabase.SaveChanges();
		}
		public void Edit(GroupExtendedProxy oldExtendedProxy, GroupExtendedProxy newExtendedProxy) {
			var foundGroup = ModelDatabase.GetGroup(oldExtendedProxy);

			foundGroup.GroupName = newExtendedProxy.GroupName;
			foundGroup.SpecialtyName = newExtendedProxy.SpecialtyName;
			foundGroup.SpecialtyNumber = newExtendedProxy.SpecialtyNumber;
			foundGroup.FacultyName = newExtendedProxy.FacultyName;

			ModelDatabase.SaveChanges();
		}
		public void Delete(GroupBasedProxy basedProxy) {
			DeleteGroup(ModelDatabase.GetGroup(basedProxy));
			ModelDatabase.SaveChanges();
		}
	}
}