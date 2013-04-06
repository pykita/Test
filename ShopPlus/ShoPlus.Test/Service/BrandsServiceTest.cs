using System;
using NUnit.Framework;
using ShopPlus.Service;
using ShopPlus.Storage;

namespace ShoPlus.Test.Service
{
    [TestFixture]
    public class BrandsServiceTest
    {
        private IBrandsStorage m_Storage;

        [SetUp]
        public void SetUp()
        {
            m_Storage = new BrandsStorage();
        }

        [Test]
        public void SuccessConstructorTest()
        {
            Assert.DoesNotThrow(() => new BrandsService(m_Storage));
        }

        [Test]
        public void FailConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() => new BrandsService(null));
        }
    }
}
