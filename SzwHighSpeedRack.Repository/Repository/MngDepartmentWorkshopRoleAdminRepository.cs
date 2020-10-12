using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngDepartmentWorkshopRoleAdminRepository : BaseRepository<MngDepartmentWorkshopRoleAdmin>, IMngDepartmentWorkshopRoleAdminRepository
    {
        public MngDepartmentWorkshopRoleAdminRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}