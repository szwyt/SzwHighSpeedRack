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
    using SzwHighSpeedRack.Model;

    /// <summary>
    /// 基类上下文.
    /// </summary>
    public class BaseContext : DbContext
    {

        public BaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets connectionString.
        /// </summary>
        protected string ConnectionString { get; set; }

        /// <summary>
        /// modelBuilder.
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(SiteCategory)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
