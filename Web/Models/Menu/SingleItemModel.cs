using Web.DTO.DataTransfer;

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
