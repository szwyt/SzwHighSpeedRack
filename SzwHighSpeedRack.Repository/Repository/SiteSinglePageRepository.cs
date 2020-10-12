using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SiteSinglePageRepository : BaseRepository<SiteSinglePage>, ISiteSinglePageRepository
    {
        public SiteSinglePageRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}