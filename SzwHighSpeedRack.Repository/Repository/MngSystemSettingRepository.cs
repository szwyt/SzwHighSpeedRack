using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngSystemSettingRepository : BaseRepository<MngSystemSetting>, IMngSystemSettingRepository
    {
        public MngSystemSettingRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}