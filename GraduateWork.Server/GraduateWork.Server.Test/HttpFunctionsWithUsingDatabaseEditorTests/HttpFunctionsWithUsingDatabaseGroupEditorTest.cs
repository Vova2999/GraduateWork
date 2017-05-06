using System;
using FakeItEasy;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Functions.Protected.WithoutReturn.Database.Group;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test.HttpFunctionsWithUsingDatabaseEditorTests {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseGroupEditorTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseGroupEditor databaseGroupEditor;

		[SetUp]
		public void SetUp() {
			databaseGroupEditor = A.Fake<IDatabaseGroupEditor>();
		}

		[Test]
		public void AddGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupExtendedProxy { GroupName = "nameOfGroup" };

			RunServer(new AddGroupFunction(DatabaseAuthorizer, databaseGroupEditor));
			SendRequest("AddGroup", GetDefaultParameters(), group.ToJson());

			A.CallTo(() => databaseGroupEditor.Add(group)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteGroupFunctionTest_ShouldBeSuccess() {
			var group = new GroupBasedProxy { GroupName = "nameOfGroup" };

			RunServer(new DeleteGroupFunction(DatabaseAuthorizer, databaseGroupEditor));
			SendRequest("DeleteGroup", GetDefaultParameters(), group.ToJson());

			A.CallTo(() => databaseGroupEditor.Delete(group)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditGroupFunctionTest_ShouldBeSuccess() {
			var firstGroup = new GroupExtendedProxy { GroupName = "firstNameOfGroup" };
			var secondGroup = new GroupExtendedProxy { GroupName = "secondNameOfGroup" };

			RunServer(new EditGroupFunction(DatabaseAuthorizer, databaseGroupEditor));
			SendRequest("EditGroup", GetDefaultParameters(), Tuple.Create(firstGroup, secondGroup).ToJson());

			A.CallTo(() => databaseGroupEditor.Edit(firstGroup, secondGroup)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}