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
        public decimal? Price { get; set; }
        public int? Grams { get; set; }
        public decimal? Calories { get; set; }
        public TimeSpan? CookingTime { get; set; }
    }
}
