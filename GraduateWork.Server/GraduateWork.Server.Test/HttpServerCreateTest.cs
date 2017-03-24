using FakeItEasy;
using GraduateWork.Server.Functions;
using GraduateWork.Server.Server;
using NUnit.Framework;

namespace GraduateWork.Server.Test {
	[TestFixture]
	public class HttpSesrverCreateTest {
		[Test]
		public void SimpleCreateTest_ShouldBeSuccess() {
			var firstFunction = A.Fake<IHttpFunction>();
			var secondFunction = A.Fake<IHttpFunction>();
			A.CallTo(() => firstFunction.NameOfCalledMethod).Returns("firstNameOfCalledMethod");
			A.CallTo(() => secondFunction.NameOfCalledMethod).Returns("secondNameOfCalledMethod");

			new HttpServer(new IHttpFunction[0]);
			new HttpServer(new[] { firstFunction });
			new HttpServer(new[] { secondFunction });
			new HttpServer(new[] { firstFunction, secondFunction });
		}

		[Test]
		public void CreateWithSameFunctionsTest_ShouldBeThrowExcetpion() {
			var firstFunction = A.Fake<IHttpFunction>();
			A.CallTo(() => firstFunction.NameOfCalledMethod).Returns("firstNameOfCalledMethod");

			Assert.Catch(() => new HttpServer(new[] { firstFunction, firstFunction }));
		}

		[Test]
		public void CreateManyFunctionsWithSameCalledNamesTest_ShouldBeThrowExcetpion() {
			var firstFunction = A.Fake<IHttpFunction>();
			var secondFunction = A.Fake<IHttpFunction>();
			A.CallTo(() => firstFunction.NameOfCalledMethod).Returns("nameOfCalledMethod");
			A.CallTo(() => secondFunction.NameOfCalledMethod).Returns("nameOfCalledMethod");

			Assert.Catch(() => new HttpServer(new[] { firstFunction, secondFunction }));
		}
	}
}