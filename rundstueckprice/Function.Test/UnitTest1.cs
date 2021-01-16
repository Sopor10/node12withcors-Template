using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace Function.Function.Test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			HttpRequest request = CreateRequest();
			var sut = new FunctionHandler();
			
			var result = sut.Handle(request);
			Assert.That(result.Result.Item1, Is.EqualTo(200));
			Assert.That(result.Result.Item2, Is.EqualTo("1"));
		}

		private HttpRequest CreateRequest()
		{
			Mock<HttpRequest> mockRequest = new Mock<HttpRequest>();
			var stream = File.OpenRead("TestObject.txt");
			mockRequest.Setup(x => x.Body).Returns(stream);
			return mockRequest.Object;
		}
	}
}
