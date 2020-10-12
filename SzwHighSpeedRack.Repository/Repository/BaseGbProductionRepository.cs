using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class BaseGbProductionRepository : BaseRepository<BaseGbProduction>, IBaseGbProductionRepository
    {
        public BaseGbProductionRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}