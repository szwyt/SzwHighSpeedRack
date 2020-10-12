using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class SalePrintLogDetailRepository : BaseRepository<SalePrintLogDetail>, ISalePrintLogDetailRepository
    {
        public SalePrintLogDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}