using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IMenuService<T>
    {
        public int Count { get; }
        T GetItem(int id);
        List<T> ListAllItems();
        List<T> SelectRange(int index, int count);
        T ChangeItem(T item);
        void AddNewItem(T item);
        void DeleteItem(int id);

    }
}
