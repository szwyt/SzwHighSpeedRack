using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdStockOutRepository : BaseRepository<PdStockOut>, IPdStockOutRepository
    {
        public PdStockOutRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}