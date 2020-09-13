using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;
namespace SzwHighSpeedRack.Repository
{
    public class MngSystemInfoRepository : BaseRepository<MngSystemInfo>, IMngSystemInfoRepository
    {
        public MngSystemInfoRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}



