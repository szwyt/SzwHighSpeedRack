using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngMenuClassRepository : BaseRepository<MngMenuClass>, IMngMenuClassRepository
    {
        public MngMenuClassRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}