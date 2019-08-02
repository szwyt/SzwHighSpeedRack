// <copyright file="IDbFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
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
        BaseContext GetDbContext(DbEnum.DbType dbType);
    }
}
