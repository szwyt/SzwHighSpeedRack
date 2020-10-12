using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdQualityProductPresetRepository : BaseRepository<PdQualityProductPreset>, IPdQualityProductPresetRepository
    {
        public PdQualityProductPresetRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}