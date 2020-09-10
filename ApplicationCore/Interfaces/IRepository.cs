using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T: MenuItem
    {
        T GetById(int id);
        List<T> ListAll();
        void Add(T entity);
        T Update(T entity);
        void Delete(T entity);

        
    }
}
