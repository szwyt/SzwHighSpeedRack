﻿// <copyright file="BaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// 基类上下文.
    /// </summary>
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
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
            Assembly assembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SzwHighSpeedRack.Entity.dll"));
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        public class EFLoggerProvider : ILoggerProvider
        {
            public ILogger CreateLogger(string categoryName) => new EFLogger(categoryName);

            public void Dispose()
            {
            }
        }

        public class EFLogger : ILogger
        {
            private readonly string categoryName;

            public EFLogger(string categoryName) => this.categoryName = categoryName;

            public IDisposable BeginScope<TState>(TState state) => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                //ef core执行数据库查询时的categoryName为Microsoft.EntityFrameworkCore.Database.Command,日志级别为Information
                if (categoryName == "Microsoft.EntityFrameworkCore.Database.Command")
                {
                    var logContent = formatter(state, exception);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(logContent);
                    Console.ResetColor();
                }
            }
        }
    }
}