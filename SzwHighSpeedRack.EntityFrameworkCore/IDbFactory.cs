// <copyright file="IDbFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// DB.
    /// </summary>
    public interface IDbFactory
    {
        /// <summary>
        /// 得到上下文.
        /// </summary>
        /// <param name="dbType">dbType.</param>
        /// <returns>BaseContext.</returns>
        BaseContext GetDbContext();

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTran();

        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTran();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTran();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int SaveChange();
    }
}
