using ApplicationCore.Entities.Data;
using ApplicationCore.Exceptions;
using ApplicationCore.Exceptions.Modifying_Data_Exceptions;
using ApplicationCore.Exceptions.ModifyingDataExceptions;
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
            catch (DbUpdateException)
            {
                throw new MenuDataException("Something went wrong.\nMake sure entered name is unique.");
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="DataDeletionException">If error occurs, throws DataDeleteException</exception>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            MenuItem item;
            try
            {
                item = _context.MenuItem.Single(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new ItemNotFoundException<MenuItem>(id);
            }
            catch(Exception)
            {
                throw new MenuDataException();
            }

            _context.MenuItem.Remove(item);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new DataDeletionException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ItemNotFoundException{T}"></exception>
        /// <exception cref="MenuDataException"></exception>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuItem GetById(int id)
        {
            MenuItem item = null;
            try
            {
                item = _context.MenuItem.Where(x => x.Id == id).Single();
            }
            catch (InvalidOperationException)
            {
                throw new  ItemNotFoundException<MenuItem>(id);
            }
            catch (Exception)
            {
                throw new MenuDataException();
            }
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="MenuDataException"></exception>
        /// <returns></returns>
        public List<MenuItem> ListAll()
        {
            List<MenuItem> items;
            try
            {
                items = _context.MenuItem.ToList();
            }
            catch (Exception)
            {
                throw new MenuDataException();
            }
            return items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="MenuDataException"></exception>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public List<MenuItem> ListAll(int index, int count, List<Expression<Func<MenuItem, bool>>> rules = null)
        {
            IQueryable<MenuItem> selectedItems = _context.MenuItem;

            if (!(rules is null))  selectedItems = selectedItems.Where(rules);
            selectedItems = selectedItems.Skip(index).Take(count);

            List<MenuItem> finalList;
            try
            {
                finalList = selectedItems.ToList();

            }
            catch (Exception)
            {

                throw new MenuDataException();
            }
            return finalList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="MenuDataException"></exception>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="orderColumn"></param>
        /// <param name="orderType"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public List<MenuItem> ListAll(int index, int count, string orderColumn, string orderType, List<Expression<Func<MenuItem, bool>>> rules = null)
        {
            IQueryable<MenuItem> selectedItems = _context.MenuItem;
            if (!(rules is null)) selectedItems = selectedItems.Where(rules);
            selectedItems = selectedItems.OrderByKey(orderColumn, orderType);
            selectedItems = selectedItems.Skip(index).Take(count);

            List<MenuItem> finalList;
            try
            {
                finalList = selectedItems.ToList();

            }
            catch (Exception)
            {
                throw new MenuDataException();
            }
            return finalList;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ItemNotFoundException{T}">Throws if item is not present in the list</exception>
        /// <exception cref="MenuDataException"></exception>
        /// <param name="entity"></param>
        /// <returns></returns>
        public MenuItem Update(MenuItem entity)
        {
            //TODO: Got to change exception catching here, but ui depends on this functionality
            var foundItem = _context.MenuItem.SingleOrDefault(x => x.Id == entity.Id);
            if (foundItem is null)
            {
                throw new ItemNotFoundException<MenuItem>(entity.Id);
            }
            else
            {
                foundItem.Title = entity.Title;
                foundItem.Description = entity.Description;
                foundItem.Ingredients = entity.Ingredients;
                foundItem.Calories = entity.Calories;
                foundItem.Grams = entity.Grams;
                foundItem.Price = entity.Price;
                foundItem.CookingTime = entity.CookingTime;
            }
            var newEntity = _context.MenuItem.Update(foundItem).Entity;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException dbexc)
            {
                throw new MenuDataException("Something went wrong.\nMake sure entered name is unique.");
            }
     
           return newEntity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="MenuDataException"></exception>
        /// <param name="rules"></param>
        /// <returns></returns>
        public List<MenuItem> Find(Func<MenuItem, bool> rules)
        {
            var selectedItems = _context.MenuItem.Where(rules);

            if (selectedItems is null)
            {
                throw new MenuDataException();
            }

            List<MenuItem> finalList;
            try
            {
                finalList = selectedItems.ToList();

            }
            catch (Exception)
            {
                throw new MenuDataException();
            }
            return finalList;
        }

    }
}
