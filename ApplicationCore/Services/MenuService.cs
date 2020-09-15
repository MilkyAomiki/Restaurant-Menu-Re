using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

//TODO: Implement methods

namespace ApplicationCore.Services
{
    public class MenuService : IMenuService<MenuItem>
    {
        public IRepository<MenuItem> Repository { get; }


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
    }
}
