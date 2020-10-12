using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngDepartmentRoleRepository : BaseRepository<MngDepartmentRole>, IMngDepartmentRoleRepository
    {
        public MngDepartmentRoleRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}