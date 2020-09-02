using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
            // 注册AOP
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<TransactionInterceptor>();

            //数据库对象注入
            List<NamedParameter> ListNamedParameter = new List<NamedParameter>()
            {
               new NamedParameter("dbType", DbEnum.DbType.MySql),
               new NamedParameter("connectionString", "Server=118.24.60.212; Port=3306; Uid=root; Pwd=123456; Database=szwHighspeedrack;SslMode=None"),
            };
            builder.RegisterType<DbContextFactory>().As<IDbFactory>().WithParameters(ListNamedParameter).SingleInstance();
            // 如果AOP拦截的是类不是接口,那么里面需要拦截的方法必须为虚方法
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ManagerService)))
                .Where(u => u.Namespace == "SzwHighSpeedRack.Service")
             .EnableClassInterceptors();
        }
    }
}
