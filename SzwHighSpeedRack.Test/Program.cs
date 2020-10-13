using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack.Repository;
using SzwHighSpeedRack.Service;

namespace SzwHighSpeedRack.Test
{
    internal class Program
    {
        private static IContainer _container;

        private static void Main(string[] args)
        {
            #region 注入测试

            var builder = new ContainerBuilder();
            //注入泛型仓储
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            // 注册AOP
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<TransactionInterceptor>();
            List<NamedParameter> ListNamedParameter = new List<NamedParameter>()
            {
               new NamedParameter("dbType", DbEnum.DbType.MySql),
               new NamedParameter("connectionString", "Server=127.0.0.1; Port=3306; Uid=root; Pwd=Aa000000; SslMode=None;Database=xyqms_base"),
            };

            //数据库对象注入
            builder.RegisterType<DbContextFactory>().As<IDbFactory>().WithParameters(ListNamedParameter).SingleInstance();

            Assembly assemblyBaseRepository = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SzwHighSpeedRack.Repository.dll"));
            Assembly assemblyService = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SzwHighSpeedRack.Service.dll"));

            builder.RegisterAssemblyTypes(assemblyBaseRepository)
              .Where(u => u.Namespace == "SzwHighSpeedRack.Repository")
              //.EnableClassInterceptors()
              //.InstancePerDependency();
              .AsImplementedInterfaces()
              .InstancePerDependency()
              .EnableInterfaceInterceptors();//引用Autofac.Extras.DynamicProxy;

            // 如果AOP拦截的是类不是接口,那么里面需要拦截的方法必须为虚方法
            builder.RegisterAssemblyTypes(assemblyService)
             .Where(u => u.Namespace == "SzwHighSpeedRack.Service")
             .EnableClassInterceptors()
             .InstancePerDependency();
            //.AsImplementedInterfaces()
            //.InstancePerDependency()
            //.EnableInterfaceInterceptors();//引用Autofac.Extras.DynamicProxy;
            _container = builder.Build();
            IPdProductRepository iuser = _container.Resolve<IPdProductRepository>();
            MngAdminService iusers = _container.Resolve<MngAdminService>();
            try
            {
                iusers.TranTest();
                //Console.WriteLine(iuser.FindList().ToJson());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion 注入测试

            //Console.WriteLine("=========================================================");
            //using (SzwHighSpeedRack.Test.Context.MySqlContext db = new SzwHighSpeedRack.Test.Context.MySqlContext())
            //{
            //using (var baseContext = DbContextFactory.CreateDbInstance(DbEnum.DbType.MySql, "Server=127.0.0.1; Port=3306; Uid=root; Pwd=Aa000000; Database=xyqms_base;SslMode=None"))
            //{
            //    var list = baseContext.Set<MngAdmin>().ToList();
            //    Console.WriteLine(list.ToJson());
            //}
            //}

            Console.ReadKey();
        }
    }
}