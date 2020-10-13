using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack.Service;

namespace SzwHighSpeedRackApi
{
    public class ModuleRegister : Autofac.Module
    {
        /// <summary>
        /// 重写Autofac管道Load方法，在这里注册注入
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //注入泛型仓储
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));
            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>));
            // 注册AOP
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<TransactionInterceptor>();
            Assembly assemblyBaseRepository = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SzwHighSpeedRack.Repository.dll"));
            Assembly assemblyService = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SzwHighSpeedRack.Service.dll"));
            //数据库对象注入
            List<NamedParameter> ListNamedParameter = new List<NamedParameter>()
            {
                new NamedParameter("dbType", DbEnum.DbType.MySql),
                new NamedParameter("connectionString", "Server=127.0.0.1; Port=3306; Uid=root; Pwd=Aa000000; Database=xyqms_base;SslMode=None"),
            };

            builder.RegisterType<DbContextFactory>().As<IDbFactory>().WithParameters(ListNamedParameter).SingleInstance();
            builder.RegisterAssemblyTypes(assemblyBaseRepository)
              .Where(u => u.Namespace == "SzwHighSpeedRack.Repository")
              //.EnableClassInterceptors()
              //.InstancePerDependency();
              .AsImplementedInterfaces()
              .InstancePerDependency()
              .EnableInterfaceInterceptors();//引用Autofac.Extras.DynamicProxy;
            // 如果AOP拦截的是类不是接口,那么里面需要拦截的方法必须为虚方法
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(MngAdminService)))
            builder.RegisterAssemblyTypes(assemblyService)
                .Where(u => u.Namespace == "SzwHighSpeedRack.Service")
             .EnableClassInterceptors();
        }
    }
}