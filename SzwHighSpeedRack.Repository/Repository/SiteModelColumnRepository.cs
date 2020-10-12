using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SiteModelColumnRepository : BaseRepository<SiteModelColumn>, ISiteModelColumnRepository
    {
        public SiteModelColumnRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}