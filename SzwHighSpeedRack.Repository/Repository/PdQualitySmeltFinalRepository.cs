using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdQualitySmeltFinalRepository : BaseRepository<PdQualitySmeltFinal>, IPdQualitySmeltFinalRepository
    {
        public PdQualitySmeltFinalRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}