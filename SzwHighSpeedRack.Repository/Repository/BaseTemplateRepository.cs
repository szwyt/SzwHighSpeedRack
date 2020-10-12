using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class BaseTemplateRepository : BaseRepository<BaseTemplate>, IBaseTemplateRepository
    {
        public BaseTemplateRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}