using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class BaseQualityStandardRepository : BaseRepository<BaseQualityStandard>, IBaseQualityStandardRepository
    {
        public BaseQualityStandardRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}