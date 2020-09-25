using ApplicationCore.Entities;
using System.Collections.Generic;

namespace Web.Models.Menu
{
    public class MenuModel
    {
        public MenuModel(List<MenuItem> menuItems, int totalItemsNum, int totalPagesNum, string orderParams = "", int pageNum = 1, MenuItem searchFields = null)
        {
            MenuItems = menuItems;
            TotalPagesNum = totalPagesNum;
            OrderParams = orderParams;
            PageNum = pageNum;
            SearchFields = searchFields;
            TotalItemsNum = totalItemsNum;
        }

        public List<MenuItem> MenuItems { get; set; }
        public int PageNum { get; set; }
        public int TotalItemsNum { get; set; }
        public int TotalPagesNum { get; set; }
        //{columnName}-{orderType}
        public string OrderParams { get; set; }
        public MenuItem SearchFields { get; set; }

    }
}
