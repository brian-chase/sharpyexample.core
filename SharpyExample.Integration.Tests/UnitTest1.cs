using NUnit.Framework;

namespace SharpyExample.Integration.Tests
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
            Assert.Pass();
        }

        [Test]
        public void Test_That_Fails()
        {
            Assert.That(false, Is.EqualTo(true));
        }
    }
}