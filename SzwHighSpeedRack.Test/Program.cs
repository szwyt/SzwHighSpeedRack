using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Reflection;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack.Service;

namespace SzwHighSpeedRack.Test
{
    class Program
    {
        private static IContainer _container;
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LogInterceptor>();
            //数据库对象注入
            builder.RegisterType<DbContextFactory>().As<IDbFactory>();
            //builder.RegisterType<MngAdminService>();
          
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ManagerService)))
                .Where(u => u.Namespace == "SzwHighSpeedRack.Service")
             .EnableClassInterceptors();
            _container = builder.Build();
            var iuser = _container.Resolve<MngAdminService>();
            var manager = _container.Resolve<ManagerService>();
            //var info = iuser.GetSiteCategoryInfo();
            //Console.WriteLine(info.ToJson());
            manager.Test();
            Console.ReadKey();
        }
    }
}
