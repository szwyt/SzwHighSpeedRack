using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SitelinkRepository : BaseRepository<Sitelink>, ISitelinkRepository
    {
        public SitelinkRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}