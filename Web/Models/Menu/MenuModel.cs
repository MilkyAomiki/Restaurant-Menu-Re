using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Menu
{
    public class MenuModel
    {
        public MenuModel(List<MenuItem> menuItems, int totalPageNum, string orderParams = "", int pageNum = 1)
        {
            MenuItems = menuItems;
            TotalPageNum = totalPageNum;
            OrderParams = orderParams;
            PageNum = pageNum;
        }

        public List<MenuItem> MenuItems { get; set; }
        public int PageNum { get; set; }
        public int TotalPageNum { get; set; }
        //{columnName}-{orderType}
        public string OrderParams { get; set; }

    }
}
