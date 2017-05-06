using System;
using FakeItEasy;
using GraduateWork.Common.Database.Editors;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Functions.Protected.WithoutReturn.Database.User;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test.HttpFunctionsWithUsingDatabaseEditorTests {
	[TestFixture]
	public class HttpFunctionsWithUsingDatabaseUserEditorTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseUserEditor databaseUserEditor;

		[SetUp]
		public void SetUp() {
			databaseUserEditor = A.Fake<IDatabaseUserEditor>();
		}

		[Test]
		public void AddUserFunctionTest_ShouldBeSuccess() {
			var user = new UserExtendedProxy { Login = "login" };

			RunServer(new AddUserFunction(DatabaseAuthorizer, databaseUserEditor));
			SendRequest("AddUser", GetDefaultParameters(), user.ToJson());

			A.CallTo(() => databaseUserEditor.Add(user)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void DeleteUserFunctionTest_ShouldBeSuccess() {
			var user = new UserBasedProxy { Login = "login" };

			RunServer(new DeleteUserFunction(DatabaseAuthorizer, databaseUserEditor));
			SendRequest("DeleteUser", GetDefaultParameters(), user.ToJson());

			A.CallTo(() => databaseUserEditor.Delete(user)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[Test]
		public void EditUserFunctionTest_ShouldBeSuccess() {
			var firstUser = new UserExtendedProxy { Login = "firstLogin" };
			var secondUser = new UserExtendedProxy { Login = "secondLogin" };

			RunServer(new EditUserFunction(DatabaseAuthorizer, databaseUserEditor));
			SendRequest("EditUser", GetDefaultParameters(), Tuple.Create(firstUser, secondUser).ToJson());

			A.CallTo(() => databaseUserEditor.Edit(firstUser, secondUser)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}