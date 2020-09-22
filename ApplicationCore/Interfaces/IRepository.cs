using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T>
    {
        public int Count { get; }
        T GetById(int id);
        List<T> ListAll();
        List<T> SelectRange(int index, int count);
        void Add(T entity);
        T Update(T entity);
        void Delete(int id);

        
    }
}
