using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//TODO: Learn more about Context.Set.Update() method
 
namespace Infrastructure.Data
{
    public class MenuRepository : IRepository<MenuItem>
    {
        public MenuContext Context { get; }

        public MenuRepository(MenuContext context)
        {
            Context = context;
        }

        public void Add(MenuItem entity)
        {
            Context.MenuItem.AddAsync(entity);
            Context.SaveChangesAsync();
        }

        public void Delete(MenuItem entity)
        {
            Context.MenuItem.Remove(entity);
            Context.SaveChangesAsync();
        }

        public MenuItem GetById(int id)
        {
            var result = Context.MenuItem.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public List<MenuItem> ListAll()
        {
            return Context.MenuItem.ToList<MenuItem>();
        }

        public MenuItem Update(MenuItem entity)
        {
           var newEntity = Context.MenuItem.Update(entity).Entity;
           Context.SaveChangesAsync();
           return newEntity;
        }
    }
}
