using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class BaseProductClassRepository : BaseRepository<BaseProductClass>, IBaseProductClassRepository
    {
        public BaseProductClassRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}