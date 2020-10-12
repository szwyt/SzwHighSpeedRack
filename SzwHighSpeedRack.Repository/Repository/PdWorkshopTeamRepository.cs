using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdWorkshopTeamRepository : BaseRepository<PdWorkshopTeam>, IPdWorkshopTeamRepository
    {
        public PdWorkshopTeamRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}