﻿// <copyright file="BaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using SzwHighSpeedRack.Entity;
    using Z.EntityFramework.Plus;

    public class BaseRepository<T> : IBaseRepository<T>, IDisposable
        where T : class
    {
        private IDbFactory _dbFactory;
        private BaseContext _baseContext;

        public BaseRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _baseContext = _dbFactory.GetDbContext();
        }

        /// <summary>
        /// 按条件判断是否存在对象
        /// true存在，false不存在
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>bool</returns>
        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            List<T> list = _baseContext.Set<T>().Where(exp).ToList();
            return list != null & list.Count > 0;
        }

        /// <summary>
        /// 按条件返回单个对象
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>T</returns>
        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {
            try
            {
                if (exp != null)
                {
                    return _baseContext.Set<T>().AsNoTracking().FirstOrDefault(exp);
                }

                return _baseContext.Set<T>().AsNoTracking().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 按条件查询返回集合
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>集合</returns>
        public List<T> FindList(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).ToList();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TKey">排序类型约束</typeparam>
        /// <param name="total">总数</param>
        /// <param name="pageindex">当前页索引</param>
        /// <param name="pagesize">显示页面大小</param>
        /// <param name="orderby">按照某个字段排序</param>
        /// <param name="wherelambda">条件</param>
        /// <param name="isorder">是否升序</param>
        /// <returns>list<T></returns>
        public PageModel<T> Page<TKey>(int pageIndex = 1, int pageSize = 10, Expression<Func<T, TKey>> orderBy = null, Expression<Func<T, bool>> exp = null, bool isOrder = true)

        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            IQueryable<T> data = isOrder ?
                 _baseContext.Set<T>().OrderBy(orderBy) :
                 _baseContext.Set<T>().OrderByDescending(orderBy);
            if (exp != null)
            {
                data = data.Where(exp).AsNoTracking();
            }

            int total = data.Count();
            return new PageModel<T>
            {
                dataCount = total,
                pageCount = (Math.Ceiling(total.ObjToDecimal() / pageSize.ObjToDecimal())).ObjToInt(),
                pageIndex = pageIndex,
                PageSize = pageSize,
                data = data.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList()
            };
        }

        /// <summary>
        /// 按条件查询总条数
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>集合</returns>
        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        public T AddEntity(T entity)
        {
            _baseContext.Set<T>().Add(entity);
            _baseContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">List<T></param>
        public void BatchAdd(List<T> entities)
        {
            _baseContext.Set<T>().AddRange(entities);
            _baseContext.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        public void UpdateEntity(T entity)
        {
            _baseContext.Set<T>().Update(entity);
            _baseContext.SaveChanges();
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities">List<T></param>
        public void BatchUpdate(List<T> entities)
        {
            _baseContext.Set<T>().UpdateRange(entities);
            _baseContext.SaveChanges();
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void DeleteEntity(T entity)
        {
            _baseContext.Set<T>().Remove(entity);
            _baseContext.SaveChanges();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">List<T></param>
        public void BatchDelete(List<T> entities)
        {
            _baseContext.Set<T>().RemoveRange(entities);
            _baseContext.SaveChanges();
        }

        /// <summary>
        ///  实现按需要只更新部分更新 如：UpdateEntity(u =>u.Id==1,u =>new User{Name="ok"});
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        public void UpdateByExp(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            if (where != null)
            {
                _baseContext.Set<T>().Where(where).Update(entity);
            }
            else
            {
                _baseContext.Set<T>().Update(entity);
            }
        }

        /// <summary>
        /// 按条件删除,如：DeleteEntity(u =>u.Id==1,u =>new User{Name="ok"});
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="  _baseContext"></param>
        /// <param name="exp"></param>
        public void DeleteByExp(Expression<Func<T, bool>> exp)
        {
            _baseContext.Set<T>().Where(exp).Delete();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> exp)

        {
            var dbSet = _baseContext.Set<T>().AsNoTracking().AsQueryable();
            if (exp != null)
            {
                dbSet = dbSet.Where(exp);
            }
            return dbSet;
        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}