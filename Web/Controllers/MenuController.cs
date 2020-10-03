using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ApplicationCore.Entities.Data;
using ApplicationCore.Entities.DataRepresentation;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.DTO;
using Web.DTO.DataDisplay;
using Web.DTO.DataTransfer;
using Web.Models.Menu;

namespace Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService<MenuItem, SearchData> menuService;

        public MenuController(IMenuService<MenuItem, SearchData> menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet("/")]
        public IActionResult Origin()
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
        public IActionResult Menu(int page = 1, string orderColumn = "", string orderType = null, SearchData searchFields = null)
        {
            List<MenuItem> items;
            int itemCount = 20;
            int downItem = itemCount * (page - 1);
            var totalPageNum = (menuService.Count - 1) / itemCount + 1;
            
            if (orderColumn != "" && orderType != null)
            {
                orderColumn = Regex.Replace(orderColumn, " ", String.Empty);
                items = menuService.ListAllItems(downItem, itemCount, orderColumn, orderType, searchFields);
            }
            else
            {
                items = menuService.ListAllItems(downItem, itemCount, searchFields);
            }

            List<MenuViewData> itemsToDisplay = new List<MenuViewData>();
            for (int i = 0; i < items.Count; i++)
            {
                MenuViewData itemToView = new MenuViewData
                {
                    Id = items[i].Id,
                    Title = items[i].Title,
                    Description = items[i].Description,
                    Ingredients = items[i].Ingredients,
                    Calories = (Convert.ToDecimal(items[i].Grams) / 100) * items[i].Calories,
                    CookingTime = TimeSpan.FromMinutes((double)items[i].CookingTime),
                    CreationDate = items[i].CreationDate,
                    Grams = items[i].Grams,
                    Price = items[i].Price

                };

                itemsToDisplay.Add(itemToView);
            }

            return View( new MenuModel(
                menuItems: itemsToDisplay, 
                totalItemsNum: menuService.Count,
                totalPagesNum: totalPageNum, 
                pageNum: page, 
                orderParams: orderColumn.ToLower() + "-" + orderType, 
                searchFields: searchFields
                ));
        }

        [HttpGet("/menu/items")]
        public PartialViewResult MenuItemsTableData(int page = 1, string orderColumn = "", string orderType = null, SearchData searchFields = null)
        {

            List<MenuItem> items;
            int itemCount = 20;
            int downItem = itemCount * (page - 1);
            var totalPageNum = (menuService.Count - 1) / itemCount + 1;

            if (orderColumn != "" && orderType != null)
            {
                orderColumn = Regex.Replace(orderColumn, " ", String.Empty);
                items = menuService.ListAllItems(downItem, itemCount, orderColumn, orderType, searchFields);
            }
            else
            {
                items = menuService.ListAllItems(downItem, itemCount, searchFields);
            }

            List<MenuViewData> itemsToDisplay = new List<MenuViewData>();
            for (int i = 0; i < items.Count; i++)
            {
                MenuViewData itemToView = new MenuViewData
                {
                    Id = items[i].Id,
                    Title = items[i].Title,
                    Description = items[i].Description,
                    Ingredients = items[i].Ingredients,
                    Calories = (Convert.ToDecimal(items[i].Grams) / 100) * items[i].Calories,
                    CookingTime = TimeSpan.FromMinutes((double)items[i].CookingTime),
                    CreationDate = items[i].CreationDate,
                    Grams = items[i].Grams,
                    Price = items[i].Price

                };

                itemsToDisplay.Add(itemToView);
            }
            return PartialView("_MenuItemsTableData", itemsToDisplay);
        }

        [HttpPost("/menu")]
        public IActionResult CreateItem([Bind("Title,Ingredients,Description,Price,Grams,Calories,CookingTime")] MenuItemDTO item)
        {
            var sendItem = Mapper.Map(item);
            try
            {
                menuService.AddNewItem(sendItem);
            }
            catch (TitleException titleExc)
            {
                ModelState.AddModelError("Title#" ,titleExc.Message);
                return View("NewItem", item);
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
            catch (TitleException titleExc)
            {
                ModelState.AddModelError("MenuItem.Title#", titleExc.Message);
                return View("SingleItem", new SingleItemModel(item, true));
            }

            return RedirectToAction("SingleItem", new { id = sendItem.Id });
        }

        [HttpPost("/menu/delete")]
        public IActionResult DeleteItem(int id)
        {
            menuService.DeleteItem(id);
            return Ok();
        }

    }
}