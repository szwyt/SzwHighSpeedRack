using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SaleSellerAuthRepository : BaseRepository<SaleSellerAuth>, ISaleSellerAuthRepository
    {
        public SaleSellerAuthRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}