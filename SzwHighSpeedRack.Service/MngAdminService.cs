using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack.Model;
using SzwHighSpeedRack.Utility;

namespace SzwHighSpeedRack.Service
{
    [Intercept(typeof(LogInterceptor))]
    public partial class MngAdminService : BaseService
    {
        public MngAdminService(IDbFactory factory)
            : base(factory)
        {
        }

        public SiteCategoryDto GetSiteCategoryInfo(Expression<Func<SiteCategory, bool>> exp = null)
        {
            return new EmitMapperEx().Mapper<SiteCategory, SiteCategoryDto>(db.FindSingle<SiteCategory>(f => f.Id == 1));
        }
    }
}
