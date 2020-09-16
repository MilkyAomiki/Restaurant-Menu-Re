using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Menu
{
    public class MenuModel
    {
        public MenuModel(List<MenuItem> menuItems, int pageNum)
        {
            MenuItems = menuItems;
            PageNum = pageNum;
        }

        public List<MenuItem> MenuItems { get; set; }
        public int PageNum { get; set; }


    }
}
