using ApplicationCore.DataTransformation;
using ApplicationCore.Entities.Data;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

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
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException dbexc)
            {
                var innerexc = dbexc.InnerException;
                string columnName = String.Empty;
                if (innerexc is SqlException)
                {
                    var columnNameMatch = Regex.Match(innerexc.Message, @"\(\w*|\d\)");
                    if (columnNameMatch.Success)
                    {
                        var reg = new Regex(@"\(|\)");
                        columnName = reg.Replace(columnNameMatch.Value, String.Empty);
                        throw new TitleException(columnName, $"Given title '{columnName}' have already been created");
                    }

                }
                throw;
            }
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

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException dbexc)
            {
                var innerexc = dbexc.InnerException;
                string columnName = String.Empty;
                if (innerexc is SqlException)
                {
                    var columnNameMatch = Regex.Match(innerexc.Message, @"\(\w*|\d\)");
                    if (columnNameMatch.Success)
                    {
                        var reg = new Regex(@"\(|\)");
                        columnName = reg.Replace(columnNameMatch.Value, String.Empty);
                        var titleExc = new TitleException(columnName, $"Given title '{columnName}' have already been created");

                        throw titleExc;
                    }
                    
                }
                throw;
            }
     
           return newEntity;
        }

        public List<MenuItem> Find(Func<MenuItem, bool> rules)
        {
            var foundItems = _context.MenuItem.Where(rules);
            return foundItems.ToList();
        }
    }
}
