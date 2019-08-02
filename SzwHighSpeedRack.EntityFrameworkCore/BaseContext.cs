// <copyright file="BaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 基类上下文.
    /// </summary>
    public class BaseContext : DbContext
    {
        /// <summary>
        /// Gets connectionString.
        /// </summary>
        protected string ConnectionString => string.Empty;

        /// <summary>
        /// modelBuilder.
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.LoadFile($"{AppDomain.CurrentDomain.BaseDirectory}SzwHighSpeedRack.Model"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
