using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public MenuItem Update(MenuItem entity)
        {
           var newEntity = _context.MenuItem.Update(entity).Entity;
           _context.SaveChanges();
           return newEntity;
        }

        public List<MenuItem> SelectRange(int index, int count)
        {
            var selectedItems = _context.MenuItem.Skip(index).Take(count);
            return selectedItems.ToList();
        }
    }
}
