using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("/menu")]
        public IActionResult Menu()
        {
            var items = menuService.ListAllItems();
            
            return View(new MenuModel(items, 0));
        }
        //Should precede SingleItem method
        [HttpGet("/menu/new")]
        public IActionResult NewItem()
        {
            return View();
        }

        [HttpGet("/menu/{id}")]
        public IActionResult SingleItem(int id)
        {
            var item = menuService.GetItem(id);

            return View(new SingleItemModel(item));
        }
       
    }
}
