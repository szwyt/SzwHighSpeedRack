using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdQrcodePrintedLogRepository : BaseRepository<PdQrcodePrintedLog>, IPdQrcodePrintedLogRepository
    {
        public PdQrcodePrintedLogRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}