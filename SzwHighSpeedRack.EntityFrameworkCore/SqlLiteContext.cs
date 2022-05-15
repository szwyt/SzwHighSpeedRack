// <copyright file="SqlLiteContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// SqlLiteContext.
    /// </summary>
    public class SqlLiteContext : BaseContext
    {
        public SqlLiteContext(DbContextOptions options) : base(options)
        {
        }
        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(this.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}