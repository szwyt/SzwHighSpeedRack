using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SaleSellerAuthDetailRepository : BaseRepository<SaleSellerAuthDetail>, ISaleSellerAuthDetailRepository
    {
        public SaleSellerAuthDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}