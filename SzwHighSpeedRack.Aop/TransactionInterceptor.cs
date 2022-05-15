using Castle.DynamicProxy;
using System;
using System.Reflection;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Aop
{
    /// <summary>
    /// 数据库事务AOP
    /// 作者：史梓威
    /// 创建时间：2019-05-08
    /// </summary>
    public class TransactionInterceptor : IInterceptor
    {      
        private readonly IUnitOfWork _unitOfWork;

        public TransactionInterceptor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            Type type = invocation.TargetType;
            bool isOpenTransaction = true;
            var attributes = invocation.Method.GetCustomAttribute(typeof(TransactionAttribute), true);
            if (attributes != null)
            {
                TransactionAttribute attr = (TransactionAttribute)attributes;
                isOpenTransaction = attr.IsOpenTransaction;
            }

            if (isOpenTransaction)
            {
                using (var tran = _unitOfWork.BeginTransaction())
                {
                    try
                    {
                        invocation.Proceed();
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
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