using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SiteBasicRepository : BaseRepository<SiteBasic>, ISiteBasicRepository
    {
        public SiteBasicRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}