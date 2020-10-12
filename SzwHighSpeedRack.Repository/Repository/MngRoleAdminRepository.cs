using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngRoleAdminRepository : BaseRepository<MngRoleAdmin>, IMngRoleAdminRepository
    {
        public MngRoleAdminRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}