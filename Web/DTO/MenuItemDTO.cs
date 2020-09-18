using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class MenuItemDTO
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        [FromForm]
        public string Title { get; set; }
        [FromForm]
        public string Description { get; set; }
        [FromForm]
        public string Ingredients { get; set; }
        [FromForm]
        public int? Grams { get; set; }
        [FromForm]
        public decimal? Calories { get; set; }
        [FromForm]
        public int? CookingTime { get; set; }
        [FromForm]
        public decimal? Price { get; set; }
        [FromForm]
        public DateTime CreationDate { get; set; }
    }
}
