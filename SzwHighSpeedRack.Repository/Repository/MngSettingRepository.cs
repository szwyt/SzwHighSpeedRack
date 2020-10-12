using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngSettingRepository : BaseRepository<MngSetting>, IMngSettingRepository
    {
        public MngSettingRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}