using System;

namespace Web.DTO.DataDisplay
{
    public class MenuViewData
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int? Grams { get; set; }
        public string Calories { get; set; }
        //public TimeSpan? CookingTime { get; set; }
        public string CookingTime { get; set; }
    }
}
