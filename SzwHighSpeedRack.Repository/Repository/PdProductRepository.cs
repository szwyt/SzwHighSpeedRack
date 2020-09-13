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
    public class PdProductRepository : BaseRepository<PdProduct>, IPdProductRepository
    {
        public PdProductRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}



