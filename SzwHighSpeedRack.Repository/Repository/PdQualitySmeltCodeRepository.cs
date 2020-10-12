using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdQualitySmeltCodeRepository : BaseRepository<PdQualitySmeltCode>, IPdQualitySmeltCodeRepository
    {
        public PdQualitySmeltCodeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}