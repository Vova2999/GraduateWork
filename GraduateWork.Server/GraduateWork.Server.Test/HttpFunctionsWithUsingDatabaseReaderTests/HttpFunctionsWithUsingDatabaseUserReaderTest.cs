using FakeItEasy;
using GraduateWork.Common.Database.Readers;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;
using GraduateWork.Common.Tables.Proxies.Baseds;
using GraduateWork.Common.Tables.Proxies.Extendeds;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithoutUsingFilters;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetBasedProxies.WithUsingFilters;
using GraduateWork.Server.Functions.Protected.WithReturn.Database.GetExtendedProxy;
using GraduateWork.Server.Test.BaseClasses;
using NUnit.Framework;

namespace GraduateWork.Server.Test.HttpFunctionsWithUsingDatabaseReaderTests {
	public class HttpFunctionsWithUsingDatabaseUserReaderTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseUserReader databaseReader;

		[SetUp]
		public void SetUp() {
			databaseReader = A.Fake<IDatabaseUserReader>();
		}

		[Test]
		public void GetAllUsersFunctionTest_ShouldBeSuccess() {
			var inputUsers = new[] {
				new UserBasedProxy { Login = "firstLogin" },
				new UserBasedProxy { Login = "secondLogin" }
			};
			A.CallTo(() => databaseReader.GetAllBasedProies()).Returns(inputUsers);

			RunServer(new GetAllUsersFunction(DatabaseAuthorizer, databaseReader));
			var receivedUsers = SendRequest<UserBasedProxy[]>("GetAllUsers", GetDefaultParameters());

			A.CallTo(() => databaseReader.GetAllBasedProies()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputUsers, receivedUsers);
		}

		[Test]
		public void GetUsersWithUsingFiltersFunctionTest_ShouldBeSuccess() {
			var login = "login";
			var inputUsers = new[] {
				new UserBasedProxy { Login = "firstLogin" },
				new UserBasedProxy { Login = "secondLogin" }
			};
			A.CallTo(() => databaseReader.GetUsersWithUsingFilters(login)).Returns(inputUsers);

			RunServer(new GetUsersWithUsingFiltersFunction(DatabaseAuthorizer, databaseReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.LoginForFilter] = login;
			var receivedUsers = SendRequest<UserBasedProxy[]>("GetUsersWithUsingFilters", parameters);

			A.CallTo(() => databaseReader.GetUsersWithUsingFilters(login)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputUsers, receivedUsers);
		}

		[Test]
		public void GetExtendedUserFunctionTest_ShouldBeSuccess() {
			var inputBasedUser = new UserBasedProxy { Login = "login" };
			var inputExtendedUser = new UserExtendedProxy { Login = "login" };
			A.CallTo(() => databaseReader.GetExtendedProxy(inputBasedUser)).Returns(inputExtendedUser);

			RunServer(new GetExtendedUserFunction(DatabaseAuthorizer, databaseReader));
			var receivedUser = SendRequest<UserExtendedProxy>("GetExtendedUser", GetDefaultParameters(), inputBasedUser.ToJson());

			A.CallTo(() => databaseReader.GetExtendedProxy(inputBasedUser)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedUser, Is.EqualTo(inputExtendedUser));
		}
	}
}