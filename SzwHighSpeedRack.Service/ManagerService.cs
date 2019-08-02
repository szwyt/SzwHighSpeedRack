using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using SzwHighSpeedRack.Aop;

namespace SzwHighSpeedRack.Service
{
    [Intercept(typeof(LogInterceptor))]
    public class ManagerService
    {
        /// <summary>
        /// 必须为虚方法才可以拦截
        /// </summary>
        public virtual void Test()
        {
            Console.WriteLine("11111");
        }
    }
}
