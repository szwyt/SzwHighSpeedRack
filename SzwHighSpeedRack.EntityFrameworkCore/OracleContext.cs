// <copyright file="OracleContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;

    /// <summary>
    /// OracleContext.
    /// </summary>
    public class OracleContext : BaseContext
    {
        public OracleContext(DbContextOptions options) : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var loggerFactory = new LoggerFactory();
            //loggerFactory.AddProvider(new EFLoggerProvider());
            //optionsBuilder.UseLoggerFactory(loggerFactory);
            //optionsBuilder.UseOracle(this.ConnectionString, b => b.UseOracleSQLCompatibility("11"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}