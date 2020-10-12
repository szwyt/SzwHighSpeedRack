// <copyright file="OracleContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// OracleContext.
    /// </summary>
    public class OracleContext : BaseContext
    {
        public OracleContext(string connectionString) : base(connectionString)
        {
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(this.ConnectionString);
        }
    }
}