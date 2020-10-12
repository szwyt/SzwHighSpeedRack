using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class PdQrcodeAuthRepository : BaseRepository<PdQrcodeAuth>, IPdQrcodeAuthRepository
    {
        public PdQrcodeAuthRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}