using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdQualityRepository : BaseRepository<PdQuality>, IPdQualityRepository
    {
        public PdQualityRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}