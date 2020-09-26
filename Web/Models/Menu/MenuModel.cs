using ApplicationCore.Entities.Data;
using ApplicationCore.Entities.DataRepresentation;
using System.Collections.Generic;
using Web.DTO.DataDisplay;

namespace Web.Models.Menu
{
    public class MenuModel
    {
        public MenuModel(List<MenuViewData> menuItems, int totalItemsNum, int totalPagesNum, string orderParams = "", int pageNum = 1, SearchData searchFields = null)
        {
            MenuItems = menuItems;
            TotalPagesNum = totalPagesNum;
            OrderParams = orderParams;
            PageNum = pageNum;
            SearchFields = searchFields;
            TotalItemsNum = totalItemsNum;
        }

        public List<MenuViewData> MenuItems { get; set; }
        public int PageNum { get; set; }
        public int TotalItemsNum { get; set; }
        public int TotalPagesNum { get; set; }
        //{columnName}-{orderType}
        public string OrderParams { get; set; }
        public SearchData SearchFields { get; set; }

    }
}
