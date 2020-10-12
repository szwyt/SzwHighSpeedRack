// <copyright file="IBaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IBaseRepository<T>
        where T : class
    {
        /// <summary>
        /// 按条件返回单个对象
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>T</returns>
        T FindSingle(Expression<Func<T, bool>> exp = null);

        /// <summary>
        /// 按条件判断是否存在对象
        /// true存在，false不存在
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>bool</returns>
        bool IsExist(Expression<Func<T, bool>> exp);

        /// <summary>
        /// 按条件查询返回集合
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>集合</returns>
        List<T> FindList(Expression<Func<T, bool>> exp = null);

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
        Tuple<List<T>, int> Page<TKey>(int pageIndex = 1, int pageSize = 10, Expression<Func<T, TKey>> orderBy = null, Expression<Func<T, bool>> exp = null, bool isOrder = true);

        /// <summary>
        /// 按条件查询总条数
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>集合</returns>
        int GetCount(Expression<Func<T, bool>> exp = null);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        T AddEntity(T entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">List<T></param>
        void BatchAdd(List<T> entities);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        void UpdateEntity(T entity);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities">List<T></param>
        void BatchUpdate(List<T> entities);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void DeleteEntity(T entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">List<T></param>
        void BatchDelete(List<T> entities);

        /// <summary>
        ///  实现按需要只更新部分更新 如：Update(u =>u.Id==1,u =>new User{Name="ok"});
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        void UpdateByExp(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="exp">条件</param>
        void DeleteByExp(Expression<Func<T, bool>> exp);
    }
}