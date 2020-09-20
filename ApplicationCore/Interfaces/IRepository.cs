using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T: MenuItem
    {
        public int Count { get; }
        T GetById(int id);
        List<T> ListAll();
        List<T> ListAll(int index, int count);
        List<T> ListAll(int index, int count, string orderColumn, string orderType);
        void Add(T entity);
        T Update(T entity);
        void Delete(T entity);

        
    }
}
