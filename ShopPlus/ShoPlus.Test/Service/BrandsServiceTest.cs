using System;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using ShopPlus.Models.Brands;
using ShopPlus.Service;
using ShopPlus.Storage;

namespace ShopPlus.Test.Service
{
    [TestFixture]
    public class BrandsServiceTest
    {
        private IBrandsStorage m_Storage;

        [SetUp]
        public void SetUp()
        {
            var entityMock = new EntityMock();

            m_Storage = MockRepository.GenerateStub<IBrandsStorage>();
            m_Storage.Expect(x => x.Brands()).Return(entityMock.Brands());
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

        [Test]
        public void SuccessGetBrandsTest()
        {
            var service = new BrandsService(m_Storage);

            var brands = service.GetBrands().BrandItems;
            var firstBrand = brands.First();

            Assert.AreEqual(3, brands.Length);
            Assert.AreEqual(1, firstBrand.Id);
            Assert.AreEqual("Abibas", firstBrand.Name);
        }

        [Test]
        public void FailGetBrandTest()
        {
            var service = new BrandsService(m_Storage);

            Assert.IsNull(service.GetBrandItem(65));
        }

        [Test]
        public void SuccessGetBrandTest()
        {
            var service = new BrandsService(m_Storage);

            var brand = service.GetBrandItem(0);

            Assert.AreEqual(0, brand.Id);
            Assert.AreEqual("New Brand", brand.Name);
        }

        [Test]
        public void SuccessSaveBrandTest()
        {
            var service = new BrandsService(m_Storage);
            Assert.IsTrue(service.SaveBrandItem(new BrandItem
                {
                    Id = 0,
                    Name = "fdg"
                }));
        }

        [Test]
        public void NullInputSaveBrandTest()
        {
            var service = new BrandsService(m_Storage);
            Assert.IsFalse(service.SaveBrandItem(null));
        }

        [Test]
        public void SaveNotExistBrandTest()
        {
            var service = new BrandsService(m_Storage);
            Assert.IsFalse(service.SaveBrandItem(new BrandItem
                {
                    Id = 654
                }));
        }

        [Test]
        public void SuccessDeleteBrandTest()
        {
            var service = new BrandsService(m_Storage);
            Assert.IsTrue(service.DeleteBrand(0));
        }

        [Test]
        public void FailDeleteBrandTest()
        {
            var service = new BrandsService(m_Storage);
            Assert.IsFalse(service.DeleteBrand(654));
        }

        [Test]
        public void SuccessCreateBrandTest()
        {
            var service = new BrandsService(m_Storage);
            Assert.IsTrue(service.CreateBrand(new BrandItem
                {
                    Name = "sdfgh"
                }));
        }

        [Test]
        public void FailCreateBrandTest()
        {
            var service = new BrandsService(m_Storage);
            Assert.IsFalse(service.CreateBrand(null));
        }
    }
}
