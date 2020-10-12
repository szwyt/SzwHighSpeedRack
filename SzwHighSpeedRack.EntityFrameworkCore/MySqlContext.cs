// <copyright file="MySqlContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// MySqlContext.
    /// </summary>
    public class MySqlContext : BaseContext
    {
        public MySqlContext(string connectionString) : base(connectionString)
        {
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(this.ConnectionString);
        }
    }
}