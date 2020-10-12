using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class BaseSpecificationsRepository : BaseRepository<BaseSpecifications>, IBaseSpecificationsRepository
    {
        public BaseSpecificationsRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}