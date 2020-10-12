using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngSystemInfoRepository : BaseRepository<MngSystemInfo>, IMngSystemInfoRepository
    {
        public MngSystemInfoRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}