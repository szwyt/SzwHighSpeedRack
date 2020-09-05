using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SzwHighSpeedRack.EntityFrameworkCore;
using SzwHighSpeedRack;

namespace SzwHighSpeedRack.Aop
{
    /// <summary>
    /// 数据库事务AOP
    /// 作者：史梓威 
    /// 创建时间：2019-05-08
    /// </summary>
    public class TransactionInterceptor : IInterceptor
    {
        private IDbFactory _dbFactory;
        private BaseContext _baseContext;
        public TransactionInterceptor(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _baseContext = dbFactory.GetDbContext();
        }
        public void Intercept(IInvocation invocation)
        {
            Type type = invocation.TargetType;
            bool isOpenTransaction = true;
            var attributes = invocation.Method.GetCustomAttributes(typeof(TransactionAttribute), true);
            if (attributes != null && attributes.Length > 0)
            {
                TransactionAttribute attr = (TransactionAttribute)attributes.FirstOrDefault();
                isOpenTransaction = attr.IsOpenTransaction;
            }

            if (isOpenTransaction)
            {
                using (_dbFactory.BeginTran())
                {
                    try
                    {
                        invocation.Proceed();
                        _dbFactory.CommitTran();
                    }
                    catch (Exception)
                    {
                        _dbFactory.RollbackTran();
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
