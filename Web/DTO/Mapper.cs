using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public static class Mapper
    {
        //Когда имена свойств и их типы совпадают, не обязательно руками каждое свойство перемапливать.
        public static MenuItemDTO Map(MenuItem menuItem)
        {
            var dtoItem = new MenuItemDTO
            {
                Id = menuItem.Id,
                Title = menuItem.Title,
                Description = menuItem.Description,
                Ingredients = menuItem.Ingredients,
                Grams = menuItem.Grams,
                Calories = menuItem.Calories,
                CookingTime = menuItem.CookingTime,
                Price = menuItem.Price,
                CreationDate = menuItem.CreationDate
            };
            return dtoItem;
        }

        public static MenuItem Map(MenuItemDTO dtoItem)
        {
            var menuItem = new MenuItem
            {
                Id = dtoItem.Id,
                Title = dtoItem.Title,
                Description = dtoItem.Description,
                Ingredients = dtoItem.Ingredients,
                Grams = dtoItem.Grams,
                Calories = dtoItem.Calories,
                CookingTime = dtoItem.CookingTime,
                Price = dtoItem.Price,
                CreationDate = dtoItem.CreationDate
            };
            return menuItem;
        }
    }
}

