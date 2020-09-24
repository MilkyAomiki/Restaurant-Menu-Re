using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T>
    {
        public int Count { get; }
        T GetById(int id);
        List<T> ListAll();
        List<T> ListAll(int index, int count, List<Expression<Func<T, bool>>> rules = null);
        List<T> ListAll(int index, int count, string orderColumn, string orderType, List<Expression<Func<T, bool>>> rules = null);
        List<T> Find(Func<T, bool> rules);
        void Add(T entity);
        T Update(T entity);
        void Delete(int id);

        
    }
}
