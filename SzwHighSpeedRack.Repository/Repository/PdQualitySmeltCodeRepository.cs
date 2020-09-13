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
    public class PdQualitySmeltCodeRepository : BaseRepository<PdQualitySmeltCode>, IPdQualitySmeltCodeRepository
    {
        public PdQualitySmeltCodeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}



