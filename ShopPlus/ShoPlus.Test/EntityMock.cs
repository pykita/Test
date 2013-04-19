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

        private IQueryable<AreasNew> m_Areas = new[]
            {
                new AreasNew
                    {
                        AreaId = 0,
                        AreaName = "New Area"
                    },
                new AreasNew
                    {
                        AreaId = 1,
                        AreaName = "Abibas"
                    },
                new AreasNew
                    {
                        AreaId = 2,
                        AreaName = "Rita"
                    }
            }.AsQueryable();

        public IQueryable<AreasNew> Areas()
        {
            return m_Areas;
        }
    }
}