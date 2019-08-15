// <copyright file="BaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SzwHighSpeedRack.Entity;
    using Z.EntityFramework.Plus;

    public static class BaseRepository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseContext"></param>
        /// <param name="entity"></param>
        public static void AddEntity<T>(this BaseContext baseContext, T entity)
             where T : BaseEntity
        {
            baseContext.Set<T>().Add(entity);
            baseContext.SaveChanges();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseContext"></param>
        /// <param name="entities"></param>
        public static void BatchAddEntity<T>(this BaseContext baseContext, List<T> entities)
           where T : BaseEntity
        {
            baseContext.Set<T>().AddRange(entities);
            baseContext.SaveChanges();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseContext"></param>
        /// <param name="entities"></param>
        public static void BatchDelete<T>(this BaseContext baseContext, List<T> entities)
           where T : BaseEntity
        {
            baseContext.Set<T>().RemoveRange(entities);
            baseContext.SaveChanges();
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseContext"></param>
        /// <param name="entities"></param>
        public static void BatchUpdate<T>(this BaseContext baseContext, List<T> entities)
            where T : BaseEntity
        {
            baseContext.Set<T>().UpdateRange(entities);
            baseContext.SaveChanges();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseContext"></param>
        /// <param name="entity"></param>
        public static void Delete<T>(this BaseContext baseContext, T entity)
              where T : BaseEntity
        {
            baseContext.Set<T>().Remove(entity);
            baseContext.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseContext"></param>
        /// <param name="entity"></param>
        public static void Update<T>(this BaseContext baseContext, T entity)
             where T : BaseEntity
        {
            baseContext.Set<T>().Update(entity);
            baseContext.SaveChanges();
        }

        public static List<T> FindList<T>(this BaseContext baseContext, Expression<Func<T, bool>> exp = null)
            where T : BaseEntity
        {
            return Filter(baseContext, exp).ToList();
        }

        public static Tuple<List<T>, int> Page<TKey, T>(this BaseContext baseContext, int pageIndex = 1, int pageSize = 10, Expression<Func<T, TKey>> orderBy = null, Expression<Func<T, bool>> exp = null, bool isOrder = true)
             where T : BaseEntity
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            IQueryable<T> data = isOrder ?
               baseContext.Set<T>().OrderBy(orderBy) :
               baseContext.Set<T>().OrderByDescending(orderBy);
            if (exp != null)
            {
                data = data.Where(exp).AsNoTracking();
            }

            int total = data.Count();
            return Tuple.Create(data.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), total);
        }

        /// <summary>
        /// 按条件获取单个实体
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>T</returns>
        public static T FindSingle<T>(this BaseContext baseContext, Expression<Func<T, bool>> exp = null)
            where T : class, new()
        {
            try
            {
                if (exp != null)
                {
                    return baseContext.Set<T>().AsNoTracking().FirstOrDefault(exp);
                }

                return baseContext.Set<T>().AsNoTracking().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCount<T>(this BaseContext baseContext, Expression<Func<T, bool>> exp = null)
           where T : BaseEntity
        {
            return BaseRepository.Filter<T>(baseContext, exp).Count();
        }

        /// <summary>
        ///  实现按需要只更新部分更新 如：UpdateEntity(u =>u.Id==1,u =>new User{Name="ok"});
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        public static void UpdateEntity<T>(this BaseContext baseContext, Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
            where T : class, new()
        {
            if (where != null)
            {
                baseContext.Set<T>().Where(where).Update(entity);
            }
            else
            {
                baseContext.Set<T>().Update(entity);
            }
        }

        /// <summary>
        /// 按条件删除,如：DeleteEntity(u =>u.Id==1,u =>new User{Name="ok"});
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseContext"></param>
        /// <param name="exp"></param>
        public static void DeleteEntity<T>(this BaseContext baseContext, Expression<Func<T, bool>> exp)
           where T : BaseEntity
        {
            baseContext.Set<T>().Where(exp).Delete();
        }

        public static IQueryable<T> Filter<T>(this BaseContext baseContext, Expression<Func<T, bool>> exp)
            where T : BaseEntity
        {
            var dbSet = baseContext.Set<T>().AsNoTracking().AsQueryable();
            if (exp != null)
            {
                dbSet = dbSet.Where(exp);
            }
            return dbSet;
        }
    }
}
