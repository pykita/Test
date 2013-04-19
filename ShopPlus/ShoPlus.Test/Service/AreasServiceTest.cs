using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShopPlus.Storage;
using Rhino.Mocks;
using ShopPlus.Service;
using ShopPlus.Models.Areas;

namespace ShopPlus.Test.Service
{
    [TestFixture]
    public class AreasServiceTest
    {
        private IAreasStorage m_Storage;

        [SetUp]
        public void SetUp()
        {
            var entityMock = new EntityMock();

            m_Storage = MockRepository.GenerateStub<IAreasStorage>();
            m_Storage.Expect(x => x.Areas()).Return(entityMock.Areas());
        }

        [Test]
        public void SuccessConstructorTest()
        {
            Assert.DoesNotThrow(() => new AreasService(m_Storage));
        }

        [Test]
        public void FailConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() => new AreasService(null));
        }

        [Test]
        public void SuccessGetAreasTest()
        {
            var service = new AreasService(m_Storage);

            AreaItem[] areas = service.GetAreas().AreaItems;
            AreaItem firstArea = areas.First();

            Assert.AreEqual(3, areas.Length);
            Assert.AreEqual(1, firstArea.Id);
            Assert.AreEqual("Abibas", firstArea.AreaName);
        }

        [Test]
        public void FailGetAreaTest()
        {
            var service = new AreasService(m_Storage);

            Assert.IsNull(service.GetAreaItem(650));
        }

        [Test]
        public void SuccessGetAreaTest()
        {
            var service = new AreasService(m_Storage);

            AreaItem area = service.GetAreaItem(0);

            Assert.AreEqual(0, area.Id);
            Assert.AreEqual("New Area", area.AreaName);
        }

        [Test]
        public void SuccessSaveAreaTest()
        {
            var service = new AreasService(m_Storage);
            Assert.IsTrue(service.SaveaAreaItem(new AreaItem
            {
                AreaName = "fdg"
            }));
        }

        [Test]
        public void NullInputSaveAreaTest()
        {
            var service = new AreasService(m_Storage);
            Assert.IsFalse(service.SaveaAreaItem(null));
        }

        [Test]
        public void SaveNotExistAreaTest()
        {
            var service = new AreasService(m_Storage);
            Assert.IsFalse(service.SaveaAreaItem(new AreaItem
            {
                Id = int.MaxValue
            }));
        }

        [Test]
        public void SuccessDeleteAreaTest()
        {
            var service = new AreasService(m_Storage);
            Assert.IsTrue(service.DeleteArea(0));
        }

        [Test]
        public void FailDeleteAreaTest()
        {
            var service = new AreasService(m_Storage);
            Assert.IsFalse(service.DeleteArea(654));
        }

        [Test]
        public void SuccessCreateAreaTest()
        {
            var service = new AreasService(m_Storage);
            Assert.IsTrue(service.SaveaAreaItem(new AreaItem
            {
                AreaName = "sdfgh"
            }));
        }

        [Test]
        public void FailCreateAreaTest()
        {
            var service = new AreasService(m_Storage);
            Assert.IsFalse(service.SaveaAreaItem(null));
        }
    }
}
