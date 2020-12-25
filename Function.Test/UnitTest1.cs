using NUnit.Framework;

namespace Function.Test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestCase("97531")]
		[TestCase("441")]
		[TestCase("b97531")]
		[TestCase("531")]
		public void ValidSiteswaps(string input)
		{
			var isValid= Siteswap.TryCreate(input, out var siteswap);
			Assert.That(isValid, Is.EqualTo(true));
		}
	}
}