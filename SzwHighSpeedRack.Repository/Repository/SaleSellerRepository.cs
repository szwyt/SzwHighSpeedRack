using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SaleSellerRepository : BaseRepository<SaleSeller>, ISaleSellerRepository
    {
        public SaleSellerRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}