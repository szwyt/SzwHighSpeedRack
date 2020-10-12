using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngDepartmentClassRepository : BaseRepository<MngDepartmentClass>, IMngDepartmentClassRepository
    {
        public MngDepartmentClassRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}