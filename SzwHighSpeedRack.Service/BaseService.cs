using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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

        public T AddEntity(T entity)
        {
            return _baseRepository.AddEntity(entity);
        }

        public void BatchAdd(List<T> entities)
        {
            _baseRepository.BatchAdd(entities);
        }

        public void BatchDelete(List<T> entities)
        {
            _baseRepository.BatchDelete(entities);
        }

        public void BatchUpdate(List<T> entities)
        {
            _baseRepository.BatchUpdate(entities);
        }

        public void DeleteByExp(Expression<Func<T, bool>> exp)
        {
            _baseRepository.DeleteByExp(exp);
        }

        public void DeleteEntity(T entity)
        {
            _baseRepository.DeleteEntity(entity);
        }

        public List<T> FindList(Expression<Func<T, bool>> exp = null)
        {
            return _baseRepository.FindList(exp);
        }

        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {
            return _baseRepository.FindSingle(exp);
        }

        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            return _baseRepository.GetCount(exp);
        }

        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            return _baseRepository.IsExist(exp);
        }

        public PageModel<T> Page<TKey>(int pageIndex = 1, int pageSize = 10, Expression<Func<T, TKey>> orderBy = null, Expression<Func<T, bool>> exp = null, bool isOrder = true)
        {
            return _baseRepository.Page<TKey>(pageIndex, pageSize, orderBy, exp, isOrder);
        }

        public void UpdateByExp(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            _baseRepository.UpdateByExp(where, entity);
        }

        public void UpdateEntity(T entity)
        {
            _baseRepository.UpdateEntity(entity);
        }
    }
}