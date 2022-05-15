using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IUnitOfWork"/> 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseContext _context;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the 
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(BaseContext context)
        {
            _context = context;
        }



        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }


        public Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param = null, IDbContextTransaction trans = null) where TEntity : class
        {
            var conn = GetConnection();
            return conn.QueryAsync<TEntity>(sql, param, trans?.GetDbTransaction());

        }


        public async Task<int> ExecuteAsync(string sql, object param, IDbContextTransaction trans = null)
        {
            var conn = GetConnection();
            return await conn.ExecuteAsync(sql, param, trans?.GetDbTransaction());

        }     

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }



        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public IDbConnection GetConnection()
        {
            //_context.Database.GetDbConnection().ConnectionString = "";
            return _context.Database.GetDbConnection();
        }
    }
}
