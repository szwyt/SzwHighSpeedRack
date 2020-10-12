using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SysMobileCodeRepository : BaseRepository<SysMobileCode>, ISysMobileCodeRepository
    {
        public SysMobileCodeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}