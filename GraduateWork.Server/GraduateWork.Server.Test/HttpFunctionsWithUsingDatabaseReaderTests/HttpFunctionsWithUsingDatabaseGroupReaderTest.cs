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
	public class HttpFunctionsWithUsingDatabaseGroupReaderTest : BaseHttpServerWithUsingDatabaseAuthorizerTest {
		private IDatabaseGroupReader databaseGroupReader;

		[SetUp]
		public void SetUp() {
			databaseGroupReader = A.Fake<IDatabaseGroupReader>();
		}

		[Test]
		public void GetAllGroupsFunctionTest_ShouldBeSuccess() {
			var inputGroups = new[] {
				new GroupBasedProxy { GroupName = "firstNameOfGroup" },
				new GroupBasedProxy { GroupName = "secondNameOfGroup" }
			};
			A.CallTo(() => databaseGroupReader.GetAllBasedProies()).Returns(inputGroups);

			RunServer(new GetAllGroupsFunction(DatabaseAuthorizer, databaseGroupReader));
			var receivedGroups = SendRequest<GroupExtendedProxy[]>("GetAllGroups", GetDefaultParameters());

			A.CallTo(() => databaseGroupReader.GetAllBasedProies()).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputGroups, receivedGroups);
		}

		[Test]
		public void GetGroupsWithUsingFiltersFunctionTest_ShouldBeSuccess() {
			var groupName = "groupName";
			var specialtyNumber = 123;
			var specialtyName = "specialtyName";
			var facultyName = "facultyName";
			var inputGroups = new[] {
				new GroupBasedProxy { GroupName = "firstNameOfGroup" },
				new GroupBasedProxy { GroupName = "secondNameOfGroup" }
			};
			A.CallTo(() => databaseGroupReader.GetGroupsWithUsingFilters(groupName, specialtyNumber, specialtyName, facultyName)).Returns(inputGroups);

			RunServer(new GetGroupsWithUsingFiltersFunction(DatabaseAuthorizer, databaseGroupReader));

			var parameters = GetDefaultParameters();
			parameters[HttpParameters.GroupName] = groupName;
			parameters[HttpParameters.SpecialtyNumber] = specialtyNumber.ToString();
			parameters[HttpParameters.SpecialtyName] = specialtyName;
			parameters[HttpParameters.FacultyName] = facultyName;
			var receivedGroups = SendRequest<GroupExtendedProxy[]>("GetGroupsWithUsingFilters", parameters);

			A.CallTo(() => databaseGroupReader.GetGroupsWithUsingFilters(groupName, specialtyNumber, specialtyName, facultyName)).MustHaveHappened(Repeated.Exactly.Once);
			CollectionAssert.AreEqual(inputGroups, receivedGroups);
		}

		[Test]
		public void GetExtendedGroupFunctionTest_ShouldBeSuccess() {
			var inputBasedGroup = new GroupBasedProxy { GroupName = "firstGroup" };
			var inputExtendedGroup = new GroupExtendedProxy { GroupName = "firstGroup" };
			A.CallTo(() => databaseGroupReader.GetExtendedProxy(inputBasedGroup)).Returns(inputExtendedGroup);

			RunServer(new GetExtendedGroupFunction(DatabaseAuthorizer, databaseGroupReader));
			var receivedGroup = SendRequest<GroupExtendedProxy>("GetExtendedGroup", GetDefaultParameters(), inputBasedGroup.ToJson());

			A.CallTo(() => databaseGroupReader.GetExtendedProxy(inputBasedGroup)).MustHaveHappened(Repeated.Exactly.Once);
			Assert.That(receivedGroup, Is.EqualTo(inputExtendedGroup));
		}
	}
}