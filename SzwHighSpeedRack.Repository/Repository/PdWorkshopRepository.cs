using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdWorkshopRepository : BaseRepository<PdWorkshop>, IPdWorkshopRepository
    {
        public PdWorkshopRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}