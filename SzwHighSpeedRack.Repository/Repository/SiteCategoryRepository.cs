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
    public class SiteCategoryRepository : BaseRepository<SiteCategory>, ISiteCategoryRepository
    {
        public SiteCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}



