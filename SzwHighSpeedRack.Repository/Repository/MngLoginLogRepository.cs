using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngLoginLogRepository : BaseRepository<MngLoginLog>, IMngLoginLogRepository
    {
        public MngLoginLogRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}