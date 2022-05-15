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
        public MySqlContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL(this.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}