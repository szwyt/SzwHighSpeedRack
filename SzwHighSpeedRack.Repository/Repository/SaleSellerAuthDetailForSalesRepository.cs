using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SaleSellerAuthDetailForSalesRepository : BaseRepository<SaleSellerAuthDetailForSales>, ISaleSellerAuthDetailForSalesRepository
    {
        public SaleSellerAuthDetailForSalesRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}