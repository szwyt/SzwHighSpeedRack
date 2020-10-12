using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngAdminRepository : BaseRepository<MngAdmin>, IMngAdminRepository
    {
        public MngAdminRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}