using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        //TODO "Громозкие операции" и в целом операции лучше не делать в параметрах метода.
        //Лучше выносить в отдельные переменные
        //Так как 20, это одно и тоже логическое значение, то нужно выносить в константу
        [HttpGet("/menu")]
        public IActionResult Menu(int page = 1)
        {
            var items = menuService.SelectRange(20 * (page - 1), 20);
            var totalPageNum = (menuService.Count-1) / 20 +1;
            return View(new MenuModel(items, totalPageNum, page));
        }

        [HttpPost("/menu")]
        public IActionResult CreateItem([Bind("Title,Ingredients,Description,Price,Grams,Calories,CookingTime")] MenuItemDTO item)
        {
            try
            {
                menuService.AddNewItem(Mapper.Map(item));

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
                    }
                    ModelState.AddModelError("Title#" ,$"The given title '{columnName}' have already been created ");
                    return View("NewItem", item);
                }
                throw;
            }

            return Redirect("/menu");
        }

        [HttpGet("/menu/{id}")]
        public IActionResult SingleItem(int id)
        {
            var item = menuService.GetItem(id);

            var sendItem = Mapper.Map(item);

            return View(new SingleItemModel(sendItem));
        }

        [HttpPost("/menu/{id}")]
        public IActionResult UpdateItem(MenuItemDTO item)
        {
            if (!ModelState.IsValid)
            {
                return View("SingleItem", new SingleItemModel(item, true));
            }
            var sendItem = Mapper.Map(item);
            try
            {
                sendItem = menuService.ChangeItem(sendItem);
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
                    }
                    ModelState.AddModelError("MenuItem.Title#", $"Given title '{columnName}' have already been created ");
                    return View("SingleItem", new SingleItemModel(item, true));
                }
                throw;
            }


            return RedirectToAction("SingleItem", new { id = sendItem.Id });
        }

        //TODO Для удаления нужно, чтобы DeleteItem принимал Id
        [HttpPost("/menu/delete")]
        public IActionResult DeleteItem(int id)
        {
            var item = menuService.GetItem(id);
            menuService.DeleteItem(item);
            return Ok();
        }

    }
}