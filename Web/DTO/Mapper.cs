using ApplicationCore.Entities;

namespace Web.DTO
{
    public static class Mapper
    {
        public static MenuItemDTO Map(ApplicationCore.Entities.MenuItem menuItem)
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

        public static ApplicationCore.Entities.MenuItem Map(MenuItemDTO dtoItem)
        {
            var menuItem = new ApplicationCore.Entities.MenuItem
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

