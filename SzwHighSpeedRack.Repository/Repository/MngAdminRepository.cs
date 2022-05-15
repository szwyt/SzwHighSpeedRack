using Microsoft.EntityFrameworkCore;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Repository
{
    public class MngAdminRepository : BaseRepository<MngAdmin>, IMngAdminRepository
    {
        public MngAdminRepository(BaseContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}