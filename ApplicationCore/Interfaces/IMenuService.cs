using System;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IMenuService<T, S>
    {
        public int Count { get; }
        T GetItem(int id);
        List<T> ListAllItems();
        List<T> ListAllItems(int index, int count, S searchItem);
        List<T> ListAllItems(int index, int count, string orderColumn, string orderType, S searchItem);
        List<T> Find(Func<T, bool> rules);
        T ChangeItem(T item);
        void AddNewItem(T item);
        void DeleteItem(int id);

    }
}
