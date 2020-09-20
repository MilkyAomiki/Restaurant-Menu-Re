using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Learn more about Context.Set.Update() method

namespace Infrastructure.Data
{
    public class MenuRepository : IRepository<MenuItem>
    {
        //Нужна ему публичность ?
        public MenuContext Context { get; }

        public int Count => Context.MenuItem.Count();

        public MenuRepository(MenuContext context)
        {
            Context = context;
        }

        public void Add(MenuItem entity)
        {
             Context.MenuItem.Add(entity);
             Context.SaveChanges();
        }

        public void Delete(MenuItem entity)
        {
            Context.MenuItem.Remove(entity);
            Context.SaveChanges();
        }

        public MenuItem GetById(int id)
        {
            var result = Context.MenuItem.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public List<MenuItem> ListAll()
        {
            //TODO Зачем <MenuItem> ?
            var items = Context.MenuItem.ToList<MenuItem>();
            return items;
        }

        public MenuItem Update(MenuItem entity)
        {
           var newEntity = Context.MenuItem.Update(entity).Entity;
           Context.SaveChanges();
           return newEntity;
        }

        public List<MenuItem> SelectRange(int index, int count)
        {
            var selectedItems = Context.MenuItem.Skip(index).Take(count);
            return selectedItems.ToList();
        }
    }
}
