using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack;
using SzwHighSpeedRack.Repository;

namespace SzwHighSpeedRack.Service
{
    [Intercept(typeof(TransactionInterceptor))]
    [Intercept(typeof(LogInterceptor))]
    public partial class MngAdminService
    {
        private readonly IMngAdminRepository _mngAdminRepository;
        public MngAdminService(IMngAdminRepository mngAdminRepository)
        {
            _mngAdminRepository = mngAdminRepository;
        }

        public virtual SiteCategoryDto GetSiteCategoryInfo(Expression<Func<SiteCategory, bool>> exp = null)
        {
            return new EmitMapperExtension().Mapper<SiteCategory, SiteCategoryDto>(_mngAdminRepository.FindSingle(exp));
        }

        [Transaction(IsOpenTransaction = true)]
        public virtual int TransactionTest()
        {
            _mngAdminRepository.AddEntity(new SiteCategory
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

            _mngAdminRepository.UpdateByExp(w => w.Id == 115, u => new SiteCategory { ContentTitle = "Hello1" });
            return 1;
        }

        public virtual List<SiteCategoryDto> GetList(Expression<Func<SiteCategory, bool>> exp = null) 
        {
            return new EmitMapperExtension().MapperList<SiteCategory, SiteCategoryDto>(_mngAdminRepository.FindList(exp));
        }
    }
}
