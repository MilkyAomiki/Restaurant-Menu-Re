using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IMenuService<T> where T: MenuItem
    {
        T GetItem(int id);
        List<T> ListAllItems();
        T ChangeItem(T item);
        T AddNewItem(T item);
        T DeleteItem(T item);

    }
}
