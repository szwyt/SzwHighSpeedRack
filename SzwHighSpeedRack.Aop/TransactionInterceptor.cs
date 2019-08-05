using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack.Utility;

namespace SzwHighSpeedRack.Aop
{
    /// <summary>
    /// 数据库事务AOP
    /// 作者：史梓威 
    /// 创建时间：2019-05-08
    /// </summary>
    public class TransactionInterceptor : IInterceptor
    {
        public BaseContext BaseContext { get; set; }

        public void Intercept(IInvocation invocation)
        {
            Type type = invocation.TargetType;
            bool enabled = true;
            var props = invocation.Method.GetCustomAttributes(typeof(TransactionAttribute), true);
            if (props != null && props.Length > 0)
            {
                TransactionAttribute attr = (TransactionAttribute)props.FirstOrDefault();
                enabled = attr.Enabled;
            }

            PropertyInfo[] baseType = type.BaseType.GetProperties();
            foreach (PropertyInfo p in baseType)
            {
                if (p.PropertyType.Name == "BaseContext")
                {
                    this.BaseContext = (BaseContext)invocation.InvocationTarget.GetValue(p);
                    break;
                }
            }

            if (enabled)
            {
                using (var beginTransaction = this.BaseContext.Database.BeginTransaction())
                {
                    try
                    {
                        invocation.Proceed();
                        beginTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        beginTransaction.Rollback();
                        throw ex;
                    }
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
