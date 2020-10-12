using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class BaseBrandRepository : BaseRepository<BaseBrand>, IBaseBrandRepository
    {
        public BaseBrandRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}