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
        List<T> SelectRange(int index, int count);
        T ChangeItem(T item);
        void AddNewItem(T item);
        void DeleteItem(T item);

    }
}
