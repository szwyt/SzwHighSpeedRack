﻿// <copyright file="SqlServerContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// SqlServerContext.
    /// </summary>
    public class SqlServerContext : BaseContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }
        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(this.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}