// <copyright file="DbContextFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SzwHighSpeedRack;

    /// <summary>
    /// DB工厂.
    /// </summary>
    public class DbContextFactory : IDbFactory
    {
        // 定义一个标识确保线程同步
        private static readonly object Locker = new object();
        protected BaseContext baseContext;
        private DbEnum.DbType _dbType;
        private string _connectionString;
        private IDbContextTransaction dbContextTransaction;
        public DbContextFactory(DbEnum.DbType dbType, string connectionString)
        {
            _dbType = dbType;
            _connectionString = connectionString;
            baseContext = GetDbContext();
        }
        /// <summary>
        /// 创建DB.
        /// </summary>
        /// <param name="dbType">数据库类型.</param>
        /// <returns>BaseContext.</returns>
        public BaseContext GetDbContext()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (this.baseContext == null)
            {
                lock (Locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (this.baseContext == null)
                    {
                        this.baseContext = CreateDbInstance(_dbType, _connectionString);
                    }
                }
            }

            return this.baseContext;
        }

        /// <summary>
        /// 创建Db实例 例如:创建MySql上下文参数问MySql.
        /// </summary>
        /// <param name="dbType">Db类型.</param>
        /// <param name="connectionString">connectionString.</param>
        /// <returns>BaseContext.</returns>
        public static BaseContext CreateDbInstance(DbEnum.DbType dbType, string connectionString)
        {
            string className = string.Format("SzwHighSpeedRack.EntityFrameworkCore.{0}Context", dbType);
            try
            {
                return Activator.CreateInstance(Type.GetType(className), connectionString) as BaseContext;
            }
            catch (Exception ex)
            {
                LogModule.LogError("数据库创建异常", ex);
                throw new Exception("Create Dynamic DbInstance Error:" + ex.Message + ex.InnerException == null ? "" : ex.InnerException.Message);
            }
        }

        public IDbContextTransaction BeginTran()
        {
            dbContextTransaction = baseContext.Database.BeginTransaction();
            return dbContextTransaction;
        }

        public void CommitTran()
        {
            dbContextTransaction.Commit();
        }

        public void RollbackTran()
        {
            dbContextTransaction.Rollback();
        }

        public int SaveChange()
        {
            return baseContext.SaveChanges();
        }
    }
}
