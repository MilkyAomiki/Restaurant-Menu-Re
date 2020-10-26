using Web.DTO.DataDisplay;

namespace Web.Models.Menu
{
    public class SingleItemModel
    {
        public SingleItemModel(ItemViewData menuItem, bool editable = false)
        {
            MenuItem = menuItem;
            OpenEditable = editable;
        }
        public ItemViewData MenuItem { get; set; }
        public bool OpenEditable { get; set; }
    }
}
