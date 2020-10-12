using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdStockOutDetailRepository : BaseRepository<PdStockOutDetail>, IPdStockOutDetailRepository
    {
        public PdStockOutDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}