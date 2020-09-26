using System;

namespace ApplicationCore.Entities.Data
{
    public class MenuItem
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Grams { get; set; }
        public decimal? Calories { get; set; }
        public int? CookingTime { get; set; }
    }
}
