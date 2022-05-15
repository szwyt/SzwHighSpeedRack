using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    /// <summary>
    /// Defines the interface(s) for unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        int SaveChanges();

        /// <summary>
        /// Asynchronously saves all changes made in this unit of work to the database.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
        Task<int> SaveChangesAsync();

        #region command sql

        /// <summary>
        /// QueryAsync
        /// ag:await _unitOfWork.QueryAsync`Demo`("select id,name from school where id = @id", new { id = 1 });
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param = null, IDbContextTransaction trans = null) where TEntity : class;

        /// <summary>
        /// ExecuteAsync
        /// ag:await _unitOfWork.ExecuteAsync("update school set name =@name where id =@id", new { name = "", id=1 });
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string sql, object param, IDbContextTransaction trans = null);

        #endregion

        #region Transaction
        /// <summary>
        /// BeginTransaction
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();

        #endregion
        /// <summary>
        /// get connection
        /// </summary>
        /// <returns></returns>
        IDbConnection GetConnection();
    }
}
