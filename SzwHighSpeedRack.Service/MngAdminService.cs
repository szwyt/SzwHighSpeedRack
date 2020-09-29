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
using EmitMapper.MappingConfiguration;

namespace SzwHighSpeedRack.Service
{
    [Intercept(typeof(TransactionInterceptor))]
    [Intercept(typeof(LogInterceptor))]
    public partial class MngAdminService
    {
        private readonly ISiteCategoryRepository _siteCategoryRepository;
        private readonly IPdProductRepository _pdProductRepository;
        public MngAdminService(ISiteCategoryRepository siteCategoryRepository, IPdProductRepository pdProductRepository)
        {
            _siteCategoryRepository = siteCategoryRepository;
            _pdProductRepository = pdProductRepository;
        }
        [TransactionAttribute(IsOpenTransaction = true)]
        public virtual void TranTest()
        {
            SiteCategory siteCategory = new SiteCategory
            {
                ContentTitle = "测试add",
                HasModelContent = 11,
                Sequence = 11,
                Depth = 1,
                ParId = 1,
                ModelId = 1
            };
            _siteCategoryRepository.AddEntity(siteCategory);

            //_siteCategoryRepository.UpdateByExp(w => w.ModelId == 1, s => new SiteCategory
            //{
            //    ContentTitle = "修改11"
            //});
            int i = 0;
            int b = 10 / i;
            _pdProductRepository.DeleteByExp(w => w.Id == 2);
        }
    }
}
