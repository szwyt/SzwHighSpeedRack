// <copyright file="BaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;
    using SzwHighSpeedRack.Model;

    /// <summary>
    /// BaseRepository.
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T>
         where T : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="dbFactory">dbFactory.</param>
        public BaseRepository(IDbFactory dbFactory)
        {
            this.IDbFactory = dbFactory;
        }

        /// <inheritdoc/>
        public BaseContext DbContext
        {
            get => this.BaseContext;
            set => this.BaseContext = this.IDbFactory.GetDbContext(DbEnum.DbType.MySql);
        }

        private BaseContext BaseContext { get; set; }

        /// <summary>
        /// Gets or sets IDbFactory.
        /// </summary>
        private IDbFactory IDbFactory { get; set; }

        /// <inheritdoc/>
        public void Add(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
            this.DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void BatchAdd(List<T> entities)
        {
            this.DbContext.Set<T>().AddRange(entities);
            this.DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void BatchDelete(List<T> entities)
        {
            this.DbContext.Set<T>().RemoveRange(entities);
            this.DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void BatchUpdate(List<T> entities)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Delete(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<T> FindList(Expression<Func<T, bool>> exp = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<T> Page<TKey>(ref int total, int pageindex = 1, int pagesize = 10, Expression<Func<T, TKey>> orderby = null, Expression<Func<T, bool>> wherelambda = null, bool isorder = true)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            throw new NotImplementedException();
        }
    }
}
