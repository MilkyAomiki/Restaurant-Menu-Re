using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class MenuItemDTO
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [FromForm]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        [FromForm]
        public string Description { get; set; }

        [Required]
        [FromForm]  
        public string Ingredients { get; set; }

        [Range(0, int.MaxValue)]
        [FromForm]
        public int? Grams { get; set; }

        [Range(0,999999.99)]
        [FromForm]
        public decimal? Calories { get; set; }

        [Range(0, int.MaxValue)]
        [FromForm]
        public int? CookingTime { get; set; }

        [Range(0, double.MaxValue)]
        [FromForm]
        public decimal? Price { get; set; }

        [FromForm]
        public DateTime CreationDate { get; set; }
    }
}
