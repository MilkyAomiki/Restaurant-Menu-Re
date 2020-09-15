using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }


        [HttpPost("/")]
        public IActionResult Items()
        {
            var items = menuService.ListAllItems();
            return ;
        }


       
    }
}
