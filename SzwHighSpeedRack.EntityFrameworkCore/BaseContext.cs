// <copyright file="BaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SzwHighSpeedRack.Entity;

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
            Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "\\SzwHighSpeedRack.Entity.dll");
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
