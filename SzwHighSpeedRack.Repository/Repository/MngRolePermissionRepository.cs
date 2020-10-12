using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngRolePermissionRepository : BaseRepository<MngRolePermission>, IMngRolePermissionRepository
    {
        public MngRolePermissionRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}