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
    [Intercept(typeof(LogInterceptor))]
    public partial class MngAdminService
    {
        private IBaseRepository<SiteCategory> _siteCategory;
        public MngAdminService(IBaseRepository<SiteCategory> siteCategory)
        {
            _siteCategory = siteCategory;
        }

        public virtual SiteCategoryDto GetSiteCategoryInfo(Expression<Func<SiteCategory, bool>> exp = null)
        {
            return new EmitMapperExtension().Mapper<SiteCategory, SiteCategoryDto>(_siteCategory.FindSingle(exp));
        }

        [Transaction(Enabled = true)]
        public virtual int TransactionTest()
        {
            _siteCategory.Add(new SiteCategory
            {
                ContentTitle = "测试333",
                Depth = 2,
                HasModelContent = 20,
                ModelId = 2,
                ParId = 2,
                Sequence = 2
            });

            //int a = 0;
            //var test = 10 / a;

            _siteCategory.Update(w => w.Id == 115, u => new SiteCategory { ContentTitle = "Hello" });
            return 1;
        }
    }
}
