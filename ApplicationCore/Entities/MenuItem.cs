using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
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
        [NotMapped]
        public TimeSpan CookingTimeFormatted { get; set; }
    }
}
