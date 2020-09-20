using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;


namespace ApplicationCore.Services
{
    public class MenuService : IMenuService<MenuItem>
    {
        public IRepository<MenuItem> Repository { get; }

        public int Count => Repository.Count;

        public MenuService(IRepository<MenuItem> repository)
        {
            Repository = repository;
        }

        public void AddNewItem(MenuItem item)
        {
            Repository.Add(item);
        }

        public MenuItem ChangeItem(MenuItem item)
        {
            return Repository.Update(item);
        }

        public void DeleteItem(MenuItem item)
        {
            Repository.Delete(item);
        }

        public MenuItem GetItem(int id)
        {
            return Repository.GetById(id);
        }

        public List<MenuItem> ListAllItems()
        {
            return Repository.ListAll();
        }

        public List<MenuItem> SelectRange(int index, int count)
        {
            return Repository.SelectRange(index, count);
        }
    }
}
