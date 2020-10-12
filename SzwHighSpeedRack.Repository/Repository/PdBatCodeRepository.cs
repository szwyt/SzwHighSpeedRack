using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdBatCodeRepository : BaseRepository<PdBatCode>, IPdBatCodeRepository
    {
        public PdBatCodeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}