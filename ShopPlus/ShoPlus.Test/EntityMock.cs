using System.Linq;

namespace ShopPlus.Test
{
    public class EntityMock
    {
        private IQueryable<Brands> m_Brands = new[]
            {
                new Brands
                    {
                        BrandId = 0,
                        BrandName = "New Brand"
                    },
                new Brands
                    {
                        BrandId = 1,
                        BrandName = "Abibas"
                    },
                new Brands
                    {
                        BrandId = 2,
                        BrandName = "Rita"
                    }
            }.AsQueryable();

        public IQueryable<Brands> Brands()
        {
            return m_Brands;
        }
    }
}