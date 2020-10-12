using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SalePrintLogRepository : BaseRepository<SalePrintLog>, ISalePrintLogRepository
    {
        public SalePrintLogRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}