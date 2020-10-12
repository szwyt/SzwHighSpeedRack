using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdWorkshopTeamLogRepository : BaseRepository<PdWorkshopTeamLog>, IPdWorkshopTeamLogRepository
    {
        public PdWorkshopTeamLogRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}