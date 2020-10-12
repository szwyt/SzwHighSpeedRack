using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SiteCategoryRepository : BaseRepository<SiteCategory>, ISiteCategoryRepository
    {
        public SiteCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}