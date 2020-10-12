using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdQualityHighCodeRepository : BaseRepository<PdQualityHighCode>, IPdQualityHighCodeRepository
    {
        public PdQualityHighCodeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}