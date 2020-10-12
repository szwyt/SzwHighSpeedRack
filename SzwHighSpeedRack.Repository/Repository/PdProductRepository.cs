using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdProductRepository : BaseRepository<PdProduct>, IPdProductRepository
    {
        public PdProductRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}