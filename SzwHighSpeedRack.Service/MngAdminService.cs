using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack;

namespace SzwHighSpeedRack.Service
{
    [Intercept(typeof(TransactionInterceptor))]
    public partial class MngAdminService : BaseService
    {
        public MngAdminService(IDbFactory factory)
            : base(factory)
        {
        }

        public virtual SiteCategoryDto GetSiteCategoryInfo(Expression<Func<SiteCategory, bool>> exp = null)
        {
            return new EmitMapperExtension().Mapper<SiteCategory, SiteCategoryDto>(baseContext.FindSingle<SiteCategory>(f => f.Id == 1));
        }

        //[Transaction(true)]
        public virtual int TransactionTest()
        {
            baseContext.AddEntity(new SiteCategory
            {
                ContentTitle = "测试",
                Depth = 2,
                HasModelContent = 20,
                ModelId = 2,
                ParId = 2,
                Sequence = 2
            });

            int a = 0;
            var test = 10 / a;

            baseContext.DeleteEntity<SiteCategory>(w => w.Id == 101);
            return 1;
        }
    }
}
