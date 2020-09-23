using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class MenuRepository : IRepository<MenuItem>
    {

        private readonly MenuContext _context;

        public int Count => _context.MenuItem.Count();

        public MenuRepository(MenuContext context)
        {
            _context = context;
        }

        public void Add(MenuItem entity)
        {
             _context.MenuItem.Add(entity);
             _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.MenuItem.Where(x => x.Id == id).SingleOrDefault();
            _context.MenuItem.Remove(entity);
            _context.SaveChanges();
        }

        public MenuItem GetById(int id)
        {
            var result = _context.MenuItem.Where(x => x.Id == id).SingleOrDefault();
            return result;
        }

        public List<MenuItem> ListAll()
        {
            var items = _context.MenuItem.ToList();
            return items;
        }


        public List<MenuItem> ListAll(int index, int count, List<Expression<Func<MenuItem, bool>>> rules = null)
        {
            IQueryable<MenuItem> selectedItems = _context.MenuItem;

            if (!(rules is null))  selectedItems = selectedItems.Where(rules);
            selectedItems = selectedItems.Skip(index).Take(count);

            return selectedItems.ToList();
        }

        public List<MenuItem> ListAll(int index, int count, string orderColumn, string orderType, List<Expression<Func<MenuItem, bool>>> rules = null)
        {
            IQueryable<MenuItem> selectedItems = _context.MenuItem;

            if (!(rules is null)) selectedItems = selectedItems.Where(rules);
            selectedItems = selectedItems.OrderByKey(orderColumn, orderType);
            selectedItems = selectedItems.Skip(index).Take(count);

            return selectedItems.ToList();
        }



        public MenuItem Update(MenuItem entity)
        {
           var newEntity = _context.MenuItem.Update(entity).Entity;
           _context.SaveChanges();
           return newEntity;
        }

        public List<MenuItem> Find(Func<MenuItem, bool> rules)
        {
            var foundItems = _context.MenuItem.Where(rules);
            return foundItems.ToList();
        }
    }
}
