using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Service
{
    public class BaseService<T> : IBaseService<T>
         where T : class
    {
        private IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<T> AddEntityAsync(T entity)
        {
            return await _baseRepository.AddEntityAsync(entity);
        }

        public async Task<int> BatchAddAsync(List<T> entities)
        {
            return await _baseRepository.BatchAddAsync(entities);
        }

        public async Task<int> BatchDeleteAsync(List<T> entities)
        {
            return await _baseRepository.BatchDeleteAsync(entities);
        }

        public async Task<int> BatchUpdateAsync(List<T> entities)
        {
            return await _baseRepository.BatchUpdateAsync(entities);
        }

        public async Task<int> DeleteByExpAsync(Expression<Func<T, bool>> exp)
        {
            return await _baseRepository.DeleteByExpAsync(exp);
        }

        public async Task<int> DeleteEntityAsync(T entity)
        {
            return await _baseRepository.DeleteEntityAsync(entity);
        }

        public async Task<List<T>> FindListAsync(Expression<Func<T, bool>> exp = null)
        {
            return await _baseRepository.FindListAsync(exp);
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> exp = null)
        {
            return await _baseRepository.FindSingleAsync(exp);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> exp = null)
        {
            return await _baseRepository.GetCountAsync(exp);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> exp)
        {
            return await _baseRepository.IsExistAsync(exp);
        }

        public async Task<PageModel<T>> PageAsync<TKey>(int pageIndex = 1, int pageSize = 10, Expression<Func<T, TKey>> orderBy = null, Expression<Func<T, bool>> exp = null, bool isOrder = true)
        {
            return await _baseRepository.PageAsync(pageIndex, pageSize, orderBy, exp, isOrder);
        }

        public async Task<int> UpdateByExpAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            return await _baseRepository.UpdateByExpAsync(where, entity);
        }

        public async Task<int> UpdateEntityAsync(T entity)
        {
            return await _baseRepository.UpdateEntityAsync(entity);
        }
    }
}