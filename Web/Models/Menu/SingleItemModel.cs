using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO;

namespace Web.Models.Menu
{
    public class SingleItemModel
    {
        public SingleItemModel(MenuItemDTO menuItem, bool editable = false)
        {
            MenuItem = menuItem;
            OpenEditable = editable;
        }
        public MenuItemDTO MenuItem { get; set; }
        public bool OpenEditable { get; set; }
    }
}
