using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Menu
{
    public class SingleItemModel
    {
        public SingleItemModel(MenuItem menuItem)
        {
            MenuItem = menuItem;
        }
        public MenuItem MenuItem { get; set; }
    }
}
