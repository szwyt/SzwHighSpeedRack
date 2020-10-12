using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SaleSellerAuthForSalesRepository : BaseRepository<SaleSellerAuthForSales>, ISaleSellerAuthForSalesRepository
    {
        public SaleSellerAuthForSalesRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}