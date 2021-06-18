using System;
using NUnit.Framework;

namespace SharpyExample.Tests
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
        public void Test2()
        {
            const int i = 1;
            Assert.That(i * 5, Is.EqualTo(5));
        }

        [Test]
        public void Test3()
        {
            DateTimeOffset off = DateTimeOffset.Now;
            
            Assert.That(off, Is.LessThan(DateTimeOffset.Now));
        }
    }
}