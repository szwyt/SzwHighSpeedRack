using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SiteModelRepository : BaseRepository<SiteModel>, ISiteModelRepository
    {
        public SiteModelRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}