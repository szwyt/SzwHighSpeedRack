using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SzwHighSpeedRack.Entity;

namespace SzwHighSpeedRack.Service
{
    public interface IBaseService<T>
        where T : class
    {
        /// <summary>
        /// 按条件返回单个对象
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>T</returns>
        Task<T> FindSingleAsync(Expression<Func<T, bool>> exp = null);

        /// <summary>
        /// 按条件判断是否存在对象
        /// true存在，false不存在
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>bool</returns>
        Task<bool> IsExistAsync(Expression<Func<T, bool>> exp);

        /// <summary>
        /// 按条件查询返回集合
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>集合</returns>
        Task<List<T>> FindListAsync(Expression<Func<T, bool>> exp = null);

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
        Task<PageModel<T>>  PageAsync<TKey>(int pageIndex = 1, int pageSize = 10, Expression<Func<T, TKey>> orderBy = null, Expression<Func<T, bool>> exp = null, bool isOrder = true);

        /// <summary>
        /// 按条件查询总条数
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns>集合</returns>
        Task<int> GetCountAsync(Expression<Func<T, bool>> exp = null);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        Task<T> AddEntityAsync(T entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">List<T></param>
        Task<int> BatchAddAsync(List<T> entities);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        Task<int> UpdateEntityAsync(T entity);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities">List<T></param>
        Task<int> BatchUpdateAsync(List<T> entities);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task<int> DeleteEntityAsync(T entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">List<T></param>
        Task<int> BatchDeleteAsync(List<T> entities);

        /// <summary>
        ///  实现按需要只更新部分更新 如：Update(u =>u.Id==1,u =>new User{Name="ok"});
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        Task<int> UpdateByExpAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="exp">条件</param>
        Task<int> DeleteByExpAsync(Expression<Func<T, bool>> exp);
    }
}