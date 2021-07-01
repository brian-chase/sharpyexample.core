using NUnit.Framework;
using System.Linq;

namespace StandardClassLibrary.Services.Tests
{
    [TestFixture()]
    public class PersonServiceTests
    {
        [Test()]
        public void PeopleTest()
        {
            var svc = new PersonService();
            var list = svc.People(12);
            Assert.That(list.Count(), Is.EqualTo(12));
        }
    }
}