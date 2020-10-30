using ApplicationCore.Entities.Data;
using ApplicationCore.Entities.DataRepresentation;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Web.DTO.DataDisplay;
using Web.DTO.DataTransfer;
using Web.Models.Menu;

namespace Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService<MenuItem, SearchData> menuService;
        private readonly IMapper mapper;

        public MenuController(IMenuService<MenuItem, SearchData> menuService, IMapper mapper)
        {
            
            this.menuService = menuService;
            this.mapper = mapper;
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
            var model = new NewItemViewDTO { CurrencySymbol = new RegionInfo("en-US").ISOCurrencySymbol };
            return View(model);
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
                MenuViewData itemToView = mapper.Map<MenuItem, MenuViewData>(items[i]);
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
                MenuViewData itemToView = mapper.Map<MenuItem, MenuViewData>(items[i]);
                itemsToDisplay.Add(itemToView);
            }
            return PartialView("_MenuItemsTableData", itemsToDisplay);
        }

        [HttpPost("/menu")]
        public IActionResult CreateItem(NewItemViewDTO item)
        {
            var sendItem = mapper.Map<NewItemViewDTO, MenuItem>(item);
            if (!ModelState.IsValid)
            {
                item.CurrencySymbol = new RegionInfo("en-US").ISOCurrencySymbol;
                return View("NewItem", item);
            }
            try
            {
                menuService.AddNewItem(sendItem);
            }
            catch (MenuDataException exc)
            {
                ModelState.AddModelError("outline", exc.Message);
                item.CurrencySymbol = new RegionInfo("en-US").ISOCurrencySymbol;
                return View("NewItem", item);
            }

            return Redirect("/menu");
        }

        [HttpGet("/menu/{id}")]
        public IActionResult SingleItem(int id)
        {
            MenuItem menuItem;
            try
            {
                menuItem = menuService.GetItem(id);

            }
            catch (MenuDataException)
            {
                throw;
            }

            var sendItem = mapper.Map<MenuItem, ItemViewData>(menuItem);

            return View(new SingleItemModel(sendItem));
        }

        [HttpPost("/menu/{id}")]
        public IActionResult UpdateItem(MenuItemDTO item)
        {
            ItemViewData viewItem;
            if (!ModelState.IsValid)
            {
                viewItem = mapper.Map<MenuItemDTO, ItemViewData>(item);
                return View("SingleItem", new SingleItemModel(viewItem, true));
            }
            var sendItem = mapper.Map<MenuItemDTO, MenuItem>(item);
            try
            {
                sendItem = menuService.ChangeItem(sendItem);
            }
            catch (MenuDataException exc)
            {
                ModelState.AddModelError("outline", exc.Message);
                viewItem = mapper.Map<MenuItemDTO, ItemViewData>(item);
                return View("SingleItem", new SingleItemModel(viewItem, true));
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