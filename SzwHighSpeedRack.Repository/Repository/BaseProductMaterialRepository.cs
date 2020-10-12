using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class BaseProductMaterialRepository : BaseRepository<BaseProductMaterial>, IBaseProductMaterialRepository
    {
        public BaseProductMaterialRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}