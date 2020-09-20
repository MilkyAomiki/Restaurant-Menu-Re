using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IMenuService<T> where T: MenuItem
    {
        public int Count { get; }
        T GetItem(int id);
        List<T> ListAllItems();
        List<T> ListAllItems(int index, int count);
        List<T> ListAllItems(int index, int count, string orderColumn, string orderType);
        T ChangeItem(T item);
        void AddNewItem(T item);
        void DeleteItem(T item);

    }
}
