using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.Service;
using SzwHighSpeedRack;

namespace SzwHighSpeedRack.Test
{
    class Program
    {
        private static IContainer _container;
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            // 注册AOP
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<TransactionInterceptor>();
            //数据库对象注入
            builder.RegisterType<DbContextFactory>().As<IDbFactory>();
            //builder.RegisterType<MngAdminService>();
            // 如果AOP拦截的是类不是接口,那么里面需要拦截的方法必须为虚方法
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ManagerService)))
                .Where(u => u.Namespace == "SzwHighSpeedRack.Service")
             .EnableClassInterceptors();
            _container = builder.Build();
            var iuser = _container.Resolve<MngAdminService>();
            var manager = _container.Resolve<ManagerService>();
            var info = iuser.GetSiteCategoryInfo();
            Console.WriteLine(info.ToJson());
            //manager.Test();

            //using (var db = DbContextFactory.CreateDbInstance(DbEnum.DbType.MySql, "Server=118.24.60.212; Port=3306; Uid=root; Pwd=123456; Database=szwHighspeedrack;SslMode=None"))
            //{
            //    var first = db.Set<SiteCategory>().ToList();
            //    Console.WriteLine(first.ToJson());
            //}
            //Console.WriteLine("=========================================================");
            //using (var db = DbContextFactory.CreateDbInstance(DbEnum.DbType.MySql, "Server=dev.xiaoyutt.com; Port=7011; Uid=xyqmsep; Pwd=xyqmsep123456; Database=xyqms_base;SslMode=None"))
            //{
            //    var first = db.Set<SiteCategory>().ToList();
            //    Console.WriteLine(first.ToJson());
            //}
            Console.ReadKey();
        }
    }
}
