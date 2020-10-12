using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngRoleRepository : BaseRepository<MngRole>, IMngRoleRepository
    {
        public MngRoleRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}