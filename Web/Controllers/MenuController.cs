using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DTO;
using Web.Models.Menu;

namespace Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService<MenuItem> menuService;

        public MenuController(IMenuService<MenuItem> menuService)
        {
            this.menuService = menuService;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return Redirect("/menu");
        }
        //Should precede SingleItem method
        [HttpGet("/menu/new")]
        public IActionResult NewItem()
        {
            return View();
        }
        [HttpGet("/menu")]
        public IActionResult Menu()
        {
            var items = menuService.ListAllItems();

            return View(new MenuModel(items, 0));
        }
        [HttpPost("/menu")]
        public IActionResult CreateItem([Bind("Title,Ingredients,Description,Price,Grams,Calories,CookingTime")] MenuItem item)
        {
            menuService.AddNewItem(item);

            return Redirect("/menu");
        }
        [HttpGet("/menu/{id}")]
        public IActionResult SingleItem(int id)
        {
            var item = menuService.GetItem(id);

            return View(new SingleItemModel(item));
        }
        [HttpPost("/menu/{id}")]
        public IActionResult UpdateItem(MenuItemDTO item)
        {
            var sendItem = new MenuItem
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Ingredients = item.Ingredients,
                Grams = item.Grams,
                Calories = item.Calories,
                CookingTime = item.CookingTime,
                Price = item.Price,
                CreationDate = item.CreationDate
            };
            sendItem = menuService.ChangeItem(sendItem);
            return RedirectToAction("SingleItem", new { id = sendItem.Id });
        }


        [HttpPost("/menu/delete")]
        public IActionResult DeleteItem(int id)
        {
            var item = menuService.GetItem(id);
            menuService.DeleteItem(item);
            return Ok();
        }

    }
}