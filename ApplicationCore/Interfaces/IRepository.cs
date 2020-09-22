using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T>
    {
        public int Count { get; }
        T GetById(int id);
        List<T> ListAll();
        List<T> ListAll(int index, int count);
        List<T> ListAll(int index, int count, string orderColumn, string orderType);
        void Add(T entity);
        T Update(T entity);
        void Delete(int id);

        
    }
}
