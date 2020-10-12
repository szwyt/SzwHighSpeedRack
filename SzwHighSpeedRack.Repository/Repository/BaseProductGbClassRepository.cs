using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class BaseProductGbClassRepository : BaseRepository<BaseProductGbClass>, IBaseProductGbClassRepository
    {
        public BaseProductGbClassRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}